using chia.dotnet;
using System.Data;
using System.Net;

namespace Chia_Coin_Inspector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public uint peakheightstart;
        public uint peakheightend;
        public uint blocksperday = 4608;
        public uint nftWalletID = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPageLoad();
        }

        private async void RefreshPageLoad()
        {
            nftImage.Image = null;
            var endpoint = Config.Open().GetEndpoint("wallet");
            using (var rpcClient = new HttpRpcClient(endpoint))
            {
                var wallet = new WalletProxy(rpcClient, "test");
                var wallets = await wallet.GetWallets();
                foreach (WalletInfo info in wallets.Wallets)
                {
                    walletList.Items.Add(info.Id);
                    if (info.Type == WalletType.NFT)
                    {
                        nftWalletID = info.Id;
                    }
                }
                if (nftWalletID > 0)
                {
                    var nftwallet = new NFTWallet(nftWalletID, wallet);
                    var nftcount = await nftwallet.CountNFTs();
                    var nfts = await nftwallet.GetNFTs(0, nftcount);
                    chiarecords.DataSource = nfts;
                    blockstatuslbl.Text = "";
                    chiarecords.ClearSelection();
                }
            }
        }

        private async void walletList_SelectedIndexChanged(object sender, EventArgs e)
        {
            XCHlbl.Text = "";
            Coinslbl.Text = "";
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (walletList.SelectedIndex != -1)
            {
                List<uint> wallet_ids = new List<uint>();
                var endpoint = Config.Open().GetEndpoint("wallet");
                double mojo = 1000000000000;
                using (var rpcClient = new HttpRpcClient(endpoint))
                {
                    var wallet = new WalletProxy(rpcClient, "test");
                    wallet_ids.Add((uint)walletList.SelectedItem);
                    var wallets = await wallet.GetWallets();
                    var balances = await wallet.GetWalletBalances(wallet_ids);
                    string catname = "XCH";
                    foreach (var balance in balances)
                    {
                        if (balance.Value.WalletType.ToString() == "CAT" && !string.IsNullOrEmpty(balance.Value.AssetId))
                        {
                            var catwallet = new CATWallet(balance.Value.WalletId, wallet);
                            catname = await catwallet.GetName();
                            XCHlbl.Text = (decimal)((double)balance.Value.ConfirmedWalletBalance / mojo) + " " + catname;
                        }
                        else
                        {
                            XCHlbl.Text = (decimal)((double)balance.Value.ConfirmedWalletBalance / mojo) + " " + catname;
                        }
                        if (balance.Value.ConfirmedWalletBalance != 0)
                        {
                            var mywallet = new Wallet(balance.Value.WalletId, wallet);
                            var coins = await mywallet.GetSpendableCoins(0, 0);
                            int x = 0;
                            int y = 0;
                            chart1.Series["Fragmentation"].IsValueShownAsLabel = true;
                            foreach (var coin in coins.ConfirmedRecords)
                            {
                                x++;
                                if (Math.Round(((double)coin.Coin.Amount) / mojo, 3) > 0)
                                {
                                    chart1.Series["Fragmentation"].Points.AddXY(x, Math.Round(((double)coin.Coin.Amount) / mojo, 3));
                                }
                                else
                                {
                                    chart1.Series["Fragmentation"].Points.AddXY(x, (decimal)(((double)coin.Coin.Amount) / mojo));
                                    chart1.Series["Fragmentation"].IsValueShownAsLabel = false;
                                }
                                chart1.Series["Fragmentation"].Points[y].ToolTip = (decimal)(((double)coin.Coin.Amount) / mojo) + " " + catname + Environment.NewLine + coin.Coin.Amount.ToString() + " Mojos";
                                y++;
                            }
                            Coinslbl.Text = x.ToString() + " Coins";
                        }
                    }
                }
            }
        }

        public void ClearDataGridView(DataGridView view)
        {
            while (view.DataSource != null)
            {
                view.DataSource = null;
            }
            view.Columns.Clear();
            view.Rows.Clear();
        }

        private async void chiarecords_MouseDown(object sender, MouseEventArgs e)
        {
            var cancelSource = new CancellationTokenSource();
            var hti = chiarecords.HitTest(e.X, e.Y);
            List<CoinRecord> records = new List<CoinRecord>();
            if (hti.RowIndex < 0 || hti.ColumnIndex < 0)
            {
                return;
            }
            if (chiarecords.Rows.Count <= hti.RowIndex) return;
            if (!chiarecords[hti.ColumnIndex, hti.RowIndex].Selected)
            {
                chiarecords.ClearSelection();
                chiarecords[hti.ColumnIndex, hti.RowIndex].Selected = true;
            }
            int[] selectedrows = chiarecords.SelectedRows.Cast<DataGridViewRow>().Select(x => x.Index).Distinct().ToArray();
            if (selectedrows.Length > 0)
            {
                var endpoint = Config.Open().GetEndpoint("wallet");
                using (var rpcClient = new HttpRpcClient(endpoint))
                {
                    var wallet = new WalletProxy(rpcClient, "test");
                    foreach (int c in selectedrows)
                    {
                        if (nftWalletID > 0)
                        {
                            var nftwallet = new NFTWallet(nftWalletID, wallet);
                            var nfts = await nftwallet.GetNFTs(c, 1);
                            foreach (NFTInfo info in nfts)
                            {
                                bool redirected = false;
                                string url = "";
                                foreach (string uri in info.DataUris)
                                {
                                    if (uri.StartsWith("http"))
                                    {
                                        url = uri;
                                        blockstatuslbl.Text = "Downloading NFT image...";
                                        Tuple<int, string> retval = await downLoadImage(uri, false);
                                        if (retval.Item1 == 1) break;
                                        if (retval.Item1 == 2)
                                        {
                                            redirected = true;
                                        }
                                        blockstatuslbl.Text = "";
                                    }
                                }
                                if (redirected)
                                {
                                    Tuple<int, string> retval = await downLoadImage(url, true);
                                    if (retval.Item1 == 1)
                                    {
                                        DialogResult diagResult = MessageBox.Show("The image associated with this NFT has been moved to a new location. Would you like to update the URL in your NFT metadata? (NOTE: If this NFT image is displaying properly in your Chia wallet, no action is required)" + Environment.NewLine + Environment.NewLine + "Old URL: " + url + Environment.NewLine + "New URL: " + retval.Item2, "Modify URL", MessageBoxButtons.YesNo);
                                        if (diagResult == DialogResult.Yes)
                                        {
                                            await nftwallet.AddUri(retval.Item2, "u", info.NFTCoinID, null, 0, cancelSource.Token);
                                        }
                                    }
                                }
                            }
                            blockstatuslbl.Text = "";
                        }
                    }
                }
            }
        }

        private void Refreshbtn_Click(object sender, EventArgs e)
        {
            RefreshPageLoad();
        }

        public async Task<Tuple<int,string>> downLoadImage(string url, bool redirect)
        {
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = redirect
            };
            using (var client = new HttpClient(handler))
            {
                var response = client.GetAsync(url).Result;
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var memStream = new MemoryStream())
                        {
                            await stream.CopyToAsync(memStream);
                            memStream.Position = 0;
                            nftImage.Image = Bitmap.FromStream(memStream);
                        }
                    }
                    if (redirect)
                    {
                        return Tuple.Create(1, response.RequestMessage.RequestUri.ToString());
                    }
                    else
                    {
                        return Tuple.Create(1, url);
                    }
                }
                else if (response != null && response.StatusCode == HttpStatusCode.MovedPermanently)
                {
                    nftImage.Image = null;
                    return Tuple.Create(2, url);
                }
                else
                {
                    nftImage.Image = null;
                    return Tuple.Create(3, url);
                }
            }
        }
    }
}
