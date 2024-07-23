This tool can be used to view your NFT images outside of the Chia Reference Wallet as well as update the URI of an NFT in situations where the image has been moved.

You can download the .zip package from the release section and run "Chia_Coin_Inspector.exe" to launch the Windows Form.  Make sure you have your wallet running so the app can connect to it and read the list of NFTs.

Upon launch, the datagrid at the top of the form will be populated with a list of all your NFTs.  Clicking on a single row will cause the app to try and download the NFT image and display it on the screen.  If the app detects a redirect (which indicates a potential issue with displaying the image in your Chia wallet), you will be presented with a prompt asking if you wish to update the NFT URL. For verification purposes, both the old and new URL will be provided in the message prompt.

Clicking "Yes" will send an RPC command to the wallet requesting the update.  You can then go to your Chia wallet and the NFT you selected from the app will have an "Update Pending" notification.  Once the update is complete (and if all goes as planned), the NFT image should be displayed properly in your Chia wallet. Updating the NFT image is technically a transaction on the blockchain and the app defaults to using a fee of 0, so it can take several minutes for the update to be committed.

Go slowly and use with caution as I've performed testing of the app but only in a limited capacity.  I was able to purchase a few NFTs that exhibited the "redirect" behavior some folks have been seeing which helped me code this, but there may be conditions I did not plan for.  Please open issues and provide feedback to let me know your experience.

Additionally, there is a section at the bottom of the form that displays your Wallet IDs in a listview.  Clicking on an ID will display both the coin balance and the number of coins in that wallet. That is for identifying coin fragmentation in your wallet and is still under development.

Special thanks to Don Kackman [@dkack](https://github.com/dkackman) for their chia-dotnet library available on NuGet.
