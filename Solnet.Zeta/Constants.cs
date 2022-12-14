using Solnet.Rpc;
using Solnet.Wallet;

namespace Solnet.Zeta {
    /// <summary> 
    /// Defines constants relevant to the Zeta program and ecosystem.
    /// <remarks>
    /// For more information see:
    /// https://github.com/zetamarkets/sdk
    /// </remarks>
    /// </summary>
    public static class Constants {
        /// <summary>
        /// The Zeta Program key for <see cref="Cluster.MainNet"/>.
        /// </summary>
        public static readonly PublicKey DevNetProgramIdKey = new("BG3oRikW8d16YjUEmX3ZxHm9SiJzrGtMhsSR8aCw1Cd7");

        /// <summary>
        /// The Zeta Program key for <see cref="Cluster.MainNet"/>.
        /// </summary>
        public static readonly PublicKey MainNetProgramIdKey = new("ZETAxsqBRek56DhiGXrn75yj2NHU3aYUnxvHXpkf3aD");
    }
}