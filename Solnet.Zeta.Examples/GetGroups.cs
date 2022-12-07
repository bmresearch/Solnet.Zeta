using Solnet.Rpc;
using System;

namespace Solnet.Zeta.Examples {
    /// <summary>
    /// An example which fetches all available zeta exchanges on devnet
    /// </summary>
    public class GetExchangesExample : IRunnableExample
    {
        private readonly IRpcClient _rpcClient;
        private readonly IStreamingRpcClient _streamingRpcClient;
        private readonly ZetaClient _zetaClient;

        public GetExchangesExample() {
            Console.WriteLine($"Initializing {ToString()}");
            _rpcClient = ClientFactory.GetClient(Cluster.DevNet);
            _streamingRpcClient = ClientFactory.GetStreamingClient(Cluster.DevNet);
            _zetaClient = new ZetaClient(_rpcClient, _streamingRpcClient, Constants.DevNetProgramIdKey);
        }

        public async void Run()
        {
            var groups = await _zetaClient.GetZetaGroupsAsync(Constants.DevNetProgramIdKey);
            Console.WriteLine($"Fetched {groups.ParsedResult.Count} groups.");

            for(int i=0; i < groups.ParsedResult.Count; i++) {
                var originalRequest = groups.OriginalRequest.Result[i];
                var parsedResult = groups.ParsedResult[i];
                Console.WriteLine(
                    $"Group: {originalRequest.PublicKey}\n" +
                    $"Asset: {parsedResult.Asset}\n" +
                    $"Underlying Mint: {parsedResult.UnderlyingMint}\n" +
                    $"Expiry Interval (secs): {parsedResult.ExpiryIntervalSeconds}\n" +
                    $"Front Expiry Index: {parsedResult.FrontExpiryIndex}\n"
                );

                foreach(var product in parsedResult.Products) {
                    Console.WriteLine(
                        $"Market: {product.Market}\n" +
                        $"Kind: {product.Kind}\n" +
                        $"Strike: {(product.Strike.IsSet ? product.Strike.Value : "N/A")}"
                    );
                }
                Console.WriteLine(
                    $"Perp Market: {parsedResult.Perp.Market}\n" +
                    $"Kind: {parsedResult.Perp.Kind}\n" +
                    $"Strike: {(parsedResult.Perp.Strike.IsSet ? parsedResult.Perp.Strike.Value : "N/A")}"
                );
            }
        }
    }
}