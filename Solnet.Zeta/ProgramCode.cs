using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Solnet;
using Solnet.Programs.Abstract;
using Solnet.Programs.Utilities;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Core.Sockets;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using Solnet.Zeta;
using Solnet.Zeta.Program;
using Solnet.Zeta.Errors;
using Solnet.Zeta.Accounts;
using Solnet.Zeta.Events;
using Solnet.Zeta.Types;

namespace Solnet.Zeta
{
    namespace Accounts
    {
        public partial class Greeks
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 18343991600837481975UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{247, 213, 170, 154, 43, 243, 146, 254};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "iTJmk9pz7ob";
            public byte Nonce { get; set; }

            public ulong[] MarkPrices { get; set; }

            public ulong[] MarkPricesPadding { get; set; }

            public ulong PerpMarkPrice { get; set; }

            public ProductGreeks[] ProductGreeksType { get; set; }

            public ProductGreeks[] ProductGreeksPadding { get; set; }

            public ulong[] UpdateTimestamp { get; set; }

            public ulong[] UpdateTimestampPadding { get; set; }

            public ulong[] RetreatExpirationTimestamp { get; set; }

            public ulong[] RetreatExpirationTimestampPadding { get; set; }

            public long[] InterestRate { get; set; }

            public long[] InterestRatePadding { get; set; }

            public ulong[] Nodes { get; set; }

            public ulong[] Volatility { get; set; }

            public ulong[] VolatilityPadding { get; set; }

            public PublicKey[] NodeKeys { get; set; }

            public bool[] HaltForcePricing { get; set; }

            public ulong PerpUpdateTimestamp { get; set; }

            public AnchorDecimal PerpFundingDelta { get; set; }

            public AnchorDecimal PerpLatestFundingRate { get; set; }

            public ulong PerpLatestMidpoint { get; set; }

            public byte[] Padding { get; set; }

            public static Greeks Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                Greeks result = new Greeks();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.MarkPrices = new ulong[46];
                for (uint resultMarkPricesIdx = 0; resultMarkPricesIdx < 46; resultMarkPricesIdx++)
                {
                    result.MarkPrices[resultMarkPricesIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.MarkPricesPadding = new ulong[91];
                for (uint resultMarkPricesPaddingIdx = 0; resultMarkPricesPaddingIdx < 91; resultMarkPricesPaddingIdx++)
                {
                    result.MarkPricesPadding[resultMarkPricesPaddingIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.PerpMarkPrice = _data.GetU64(offset);
                offset += 8;
                result.ProductGreeksType = new ProductGreeks[22];
                for (uint resultProductGreeksIdx = 0; resultProductGreeksIdx < 22; resultProductGreeksIdx++)
                {
                    offset += ProductGreeks.Deserialize(_data, offset, out var resultProductGreeksresultProductGreeksIdx);
                    result.ProductGreeksType[resultProductGreeksIdx] = resultProductGreeksresultProductGreeksIdx;
                }

                result.ProductGreeksPadding = new ProductGreeks[44];
                for (uint resultProductGreeksPaddingIdx = 0; resultProductGreeksPaddingIdx < 44; resultProductGreeksPaddingIdx++)
                {
                    offset += ProductGreeks.Deserialize(_data, offset, out var resultProductGreeksPaddingresultProductGreeksPaddingIdx);
                    result.ProductGreeksPadding[resultProductGreeksPaddingIdx] = resultProductGreeksPaddingresultProductGreeksPaddingIdx;
                }

                result.UpdateTimestamp = new ulong[2];
                for (uint resultUpdateTimestampIdx = 0; resultUpdateTimestampIdx < 2; resultUpdateTimestampIdx++)
                {
                    result.UpdateTimestamp[resultUpdateTimestampIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.UpdateTimestampPadding = new ulong[4];
                for (uint resultUpdateTimestampPaddingIdx = 0; resultUpdateTimestampPaddingIdx < 4; resultUpdateTimestampPaddingIdx++)
                {
                    result.UpdateTimestampPadding[resultUpdateTimestampPaddingIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.RetreatExpirationTimestamp = new ulong[2];
                for (uint resultRetreatExpirationTimestampIdx = 0; resultRetreatExpirationTimestampIdx < 2; resultRetreatExpirationTimestampIdx++)
                {
                    result.RetreatExpirationTimestamp[resultRetreatExpirationTimestampIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.RetreatExpirationTimestampPadding = new ulong[4];
                for (uint resultRetreatExpirationTimestampPaddingIdx = 0; resultRetreatExpirationTimestampPaddingIdx < 4; resultRetreatExpirationTimestampPaddingIdx++)
                {
                    result.RetreatExpirationTimestampPadding[resultRetreatExpirationTimestampPaddingIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.InterestRate = new long[2];
                for (uint resultInterestRateIdx = 0; resultInterestRateIdx < 2; resultInterestRateIdx++)
                {
                    result.InterestRate[resultInterestRateIdx] = _data.GetS64(offset);
                    offset += 8;
                }

                result.InterestRatePadding = new long[4];
                for (uint resultInterestRatePaddingIdx = 0; resultInterestRatePaddingIdx < 4; resultInterestRatePaddingIdx++)
                {
                    result.InterestRatePadding[resultInterestRatePaddingIdx] = _data.GetS64(offset);
                    offset += 8;
                }

                result.Nodes = new ulong[5];
                for (uint resultNodesIdx = 0; resultNodesIdx < 5; resultNodesIdx++)
                {
                    result.Nodes[resultNodesIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.Volatility = new ulong[10];
                for (uint resultVolatilityIdx = 0; resultVolatilityIdx < 10; resultVolatilityIdx++)
                {
                    result.Volatility[resultVolatilityIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.VolatilityPadding = new ulong[20];
                for (uint resultVolatilityPaddingIdx = 0; resultVolatilityPaddingIdx < 20; resultVolatilityPaddingIdx++)
                {
                    result.VolatilityPadding[resultVolatilityPaddingIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.NodeKeys = new PublicKey[138];
                for (uint resultNodeKeysIdx = 0; resultNodeKeysIdx < 138; resultNodeKeysIdx++)
                {
                    result.NodeKeys[resultNodeKeysIdx] = _data.GetPubKey(offset);
                    offset += 32;
                }

                result.HaltForcePricing = new bool[6];
                for (uint resultHaltForcePricingIdx = 0; resultHaltForcePricingIdx < 6; resultHaltForcePricingIdx++)
                {
                    result.HaltForcePricing[resultHaltForcePricingIdx] = _data.GetBool(offset);
                    offset += 1;
                }

                result.PerpUpdateTimestamp = _data.GetU64(offset);
                offset += 8;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultPerpFundingDelta);
                result.PerpFundingDelta = resultPerpFundingDelta;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultPerpLatestFundingRate);
                result.PerpLatestFundingRate = resultPerpLatestFundingRate;
                result.PerpLatestMidpoint = _data.GetU64(offset);
                offset += 8;
                result.Padding = _data.GetBytes(offset, 1593);
                offset += 1593;
                return result;
            }
        }

        public partial class MarketIndexes
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 1680557187109866863UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{111, 205, 105, 146, 219, 137, 82, 23};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "Khd9dEUKcM4";
            public byte Nonce { get; set; }

            public bool Initialized { get; set; }

            public byte[] Indexes { get; set; }

            public static MarketIndexes Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                MarketIndexes result = new MarketIndexes();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Initialized = _data.GetBool(offset);
                offset += 1;
                result.Indexes = _data.GetBytes(offset, 138);
                offset += 138;
                return result;
            }
        }

        public partial class OpenOrdersMap
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 12106553715636076282UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{250, 126, 172, 10, 118, 30, 3, 168};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "iu7ahQWA1RZ";
            public PublicKey UserKey { get; set; }

            public static OpenOrdersMap Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                OpenOrdersMap result = new OpenOrdersMap();
                result.UserKey = _data.GetPubKey(offset);
                offset += 32;
                return result;
            }
        }

        public partial class State
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 12805505502107374296UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{216, 146, 107, 94, 104, 75, 182, 177};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "dE27dVH2wR2";
            public PublicKey Admin { get; set; }

            public byte StateNonce { get; set; }

            public byte SerumNonce { get; set; }

            public byte MintAuthNonce { get; set; }

            public byte NumUnderlyings { get; set; }

            public ulong Null { get; set; }

            public uint StrikeInitializationThresholdSeconds { get; set; }

            public uint PricingFrequencySeconds { get; set; }

            public uint LiquidatorLiquidationPercentage { get; set; }

            public uint InsuranceVaultLiquidationPercentage { get; set; }

            public ulong NativeD1TradeFeePercentage { get; set; }

            public ulong NativeD1UnderlyingFeePercentage { get; set; }

            public ulong NativeWhitelistUnderlyingFeePercentage { get; set; }

            public ulong NativeDepositLimit { get; set; }

            public uint ExpirationThresholdSeconds { get; set; }

            public byte PositionMovementFeeBps { get; set; }

            public byte MarginConcessionPercentage { get; set; }

            public byte TreasuryWalletNonce { get; set; }

            public ulong NativeOptionTradeFeePercentage { get; set; }

            public ulong NativeOptionUnderlyingFeePercentage { get; set; }

            public PublicKey ReferralsAdmin { get; set; }

            public byte ReferralsRewardsWalletNonce { get; set; }

            public byte[] Padding { get; set; }

            public static State Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                State result = new State();
                result.Admin = _data.GetPubKey(offset);
                offset += 32;
                result.StateNonce = _data.GetU8(offset);
                offset += 1;
                result.SerumNonce = _data.GetU8(offset);
                offset += 1;
                result.MintAuthNonce = _data.GetU8(offset);
                offset += 1;
                result.NumUnderlyings = _data.GetU8(offset);
                offset += 1;
                result.Null = _data.GetU64(offset);
                offset += 8;
                result.StrikeInitializationThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                result.PricingFrequencySeconds = _data.GetU32(offset);
                offset += 4;
                result.LiquidatorLiquidationPercentage = _data.GetU32(offset);
                offset += 4;
                result.InsuranceVaultLiquidationPercentage = _data.GetU32(offset);
                offset += 4;
                result.NativeD1TradeFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeD1UnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeWhitelistUnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeDepositLimit = _data.GetU64(offset);
                offset += 8;
                result.ExpirationThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                result.PositionMovementFeeBps = _data.GetU8(offset);
                offset += 1;
                result.MarginConcessionPercentage = _data.GetU8(offset);
                offset += 1;
                result.TreasuryWalletNonce = _data.GetU8(offset);
                offset += 1;
                result.NativeOptionTradeFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeOptionUnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.ReferralsAdmin = _data.GetPubKey(offset);
                offset += 32;
                result.ReferralsRewardsWalletNonce = _data.GetU8(offset);
                offset += 1;
                result.Padding = _data.GetBytes(offset, 107);
                offset += 107;
                return result;
            }
        }

        public partial class Underlying
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 147955165018226894UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{206, 128, 152, 77, 112, 164, 13, 2};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "bYLDDYF3xWd";
            public PublicKey Mint { get; set; }

            public static Underlying Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                Underlying result = new Underlying();
                result.Mint = _data.GetPubKey(offset);
                offset += 32;
                return result;
            }
        }

        public partial class SettlementAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 13011560660111731281UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{81, 42, 104, 111, 123, 89, 146, 180};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "EaQhKH3abYX";
            public ulong SettlementPrice { get; set; }

            public ulong[] Strikes { get; set; }

            public static SettlementAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                SettlementAccount result = new SettlementAccount();
                result.SettlementPrice = _data.GetU64(offset);
                offset += 8;
                result.Strikes = new ulong[23];
                for (uint resultStrikesIdx = 0; resultStrikesIdx < 23; resultStrikesIdx++)
                {
                    result.Strikes[resultStrikesIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                return result;
            }
        }

        public partial class PerpSyncQueue
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 4804136728140461916UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{92, 55, 56, 157, 230, 184, 171, 66};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "GRcFuMhfPUV";
            public byte Nonce { get; set; }

            public ushort Head { get; set; }

            public ushort Length { get; set; }

            public AnchorDecimal[] Queue { get; set; }

            public static PerpSyncQueue Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                PerpSyncQueue result = new PerpSyncQueue();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Head = _data.GetU16(offset);
                offset += 2;
                result.Length = _data.GetU16(offset);
                offset += 2;
                result.Queue = new AnchorDecimal[600];
                for (uint resultQueueIdx = 0; resultQueueIdx < 600; resultQueueIdx++)
                {
                    offset += AnchorDecimal.Deserialize(_data, offset, out var resultQueueresultQueueIdx);
                    result.Queue[resultQueueIdx] = resultQueueresultQueueIdx;
                }

                return result;
            }
        }

        public partial class ZetaGroup
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 868890633321976185UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{121, 17, 210, 107, 109, 235, 14, 12};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "MFXZdshps55";
            public byte Nonce { get; set; }

            public byte VaultNonce { get; set; }

            public byte InsuranceVaultNonce { get; set; }

            public byte FrontExpiryIndex { get; set; }

            public HaltState HaltState { get; set; }

            public PublicKey UnderlyingMint { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey Greeks { get; set; }

            public PricingParameters PricingParameters { get; set; }

            public MarginParameters MarginParameters { get; set; }

            public Product[] Products { get; set; }

            public Product[] ProductsPadding { get; set; }

            public Product Perp { get; set; }

            public ExpirySeries[] ExpirySeriesType { get; set; }

            public ExpirySeries[] ExpirySeriesPadding { get; set; }

            public ulong TotalInsuranceVaultDeposits { get; set; }

            public Asset Asset { get; set; }

            public uint ExpiryIntervalSeconds { get; set; }

            public uint NewExpiryThresholdSeconds { get; set; }

            public PerpParameters PerpParameters { get; set; }

            public PublicKey PerpSyncQueue { get; set; }

            public byte[] Padding { get; set; }

            public static ZetaGroup Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                ZetaGroup result = new ZetaGroup();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.VaultNonce = _data.GetU8(offset);
                offset += 1;
                result.InsuranceVaultNonce = _data.GetU8(offset);
                offset += 1;
                result.FrontExpiryIndex = _data.GetU8(offset);
                offset += 1;
                offset += HaltState.Deserialize(_data, offset, out var resultHaltState);
                result.HaltState = resultHaltState;
                result.UnderlyingMint = _data.GetPubKey(offset);
                offset += 32;
                result.Oracle = _data.GetPubKey(offset);
                offset += 32;
                result.Greeks = _data.GetPubKey(offset);
                offset += 32;
                offset += PricingParameters.Deserialize(_data, offset, out var resultPricingParameters);
                result.PricingParameters = resultPricingParameters;
                offset += MarginParameters.Deserialize(_data, offset, out var resultMarginParameters);
                result.MarginParameters = resultMarginParameters;
                result.Products = new Product[46];
                for (uint resultProductsIdx = 0; resultProductsIdx < 46; resultProductsIdx++)
                {
                    offset += Product.Deserialize(_data, offset, out var resultProductsresultProductsIdx);
                    result.Products[resultProductsIdx] = resultProductsresultProductsIdx;
                }

                result.ProductsPadding = new Product[91];
                for (uint resultProductsPaddingIdx = 0; resultProductsPaddingIdx < 91; resultProductsPaddingIdx++)
                {
                    offset += Product.Deserialize(_data, offset, out var resultProductsPaddingresultProductsPaddingIdx);
                    result.ProductsPadding[resultProductsPaddingIdx] = resultProductsPaddingresultProductsPaddingIdx;
                }

                offset += Product.Deserialize(_data, offset, out var resultPerp);
                result.Perp = resultPerp;
                result.ExpirySeriesType = new ExpirySeries[2];
                for (uint resultExpirySeriesIdx = 0; resultExpirySeriesIdx < 2; resultExpirySeriesIdx++)
                {
                    offset += ExpirySeries.Deserialize(_data, offset, out var resultExpirySeriesresultExpirySeriesIdx);
                    result.ExpirySeriesType[resultExpirySeriesIdx] = resultExpirySeriesresultExpirySeriesIdx;
                }

                result.ExpirySeriesPadding = new ExpirySeries[4];
                for (uint resultExpirySeriesPaddingIdx = 0; resultExpirySeriesPaddingIdx < 4; resultExpirySeriesPaddingIdx++)
                {
                    offset += ExpirySeries.Deserialize(_data, offset, out var resultExpirySeriesPaddingresultExpirySeriesPaddingIdx);
                    result.ExpirySeriesPadding[resultExpirySeriesPaddingIdx] = resultExpirySeriesPaddingresultExpirySeriesPaddingIdx;
                }

                result.TotalInsuranceVaultDeposits = _data.GetU64(offset);
                offset += 8;
                result.Asset = (Asset)_data.GetU8(offset);
                offset += 1;
                result.ExpiryIntervalSeconds = _data.GetU32(offset);
                offset += 4;
                result.NewExpiryThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                offset += PerpParameters.Deserialize(_data, offset, out var resultPerpParameters);
                result.PerpParameters = resultPerpParameters;
                result.PerpSyncQueue = _data.GetPubKey(offset);
                offset += 32;
                result.Padding = _data.GetBytes(offset, 998);
                offset += 998;
                return result;
            }
        }

        public partial class MarketNode
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 8952185835681567260UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{28, 82, 21, 59, 150, 141, 60, 124};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "5jkFNDqk4MH";
            public byte Index { get; set; }

            public byte Nonce { get; set; }

            public long[] NodeUpdates { get; set; }

            public long InterestUpdate { get; set; }

            public static MarketNode Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                MarketNode result = new MarketNode();
                result.Index = _data.GetU8(offset);
                offset += 1;
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.NodeUpdates = new long[5];
                for (uint resultNodeUpdatesIdx = 0; resultNodeUpdatesIdx < 5; resultNodeUpdatesIdx++)
                {
                    result.NodeUpdates[resultNodeUpdatesIdx] = _data.GetS64(offset);
                    offset += 8;
                }

                result.InterestUpdate = _data.GetS64(offset);
                offset += 8;
                return result;
            }
        }

        public partial class SpreadAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 11686754891165631033UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{57, 130, 252, 136, 167, 177, 47, 162};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "AcwF1v3w5Zb";
            public PublicKey Authority { get; set; }

            public byte Nonce { get; set; }

            public ulong Balance { get; set; }

            public ulong[] SeriesExpiry { get; set; }

            public ulong SeriesExpiryPadding { get; set; }

            public Position[] Positions { get; set; }

            public Position[] PositionsPadding { get; set; }

            public Asset Asset { get; set; }

            public byte[] Padding { get; set; }

            public static SpreadAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                SpreadAccount result = new SpreadAccount();
                result.Authority = _data.GetPubKey(offset);
                offset += 32;
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Balance = _data.GetU64(offset);
                offset += 8;
                result.SeriesExpiry = new ulong[5];
                for (uint resultSeriesExpiryIdx = 0; resultSeriesExpiryIdx < 5; resultSeriesExpiryIdx++)
                {
                    result.SeriesExpiry[resultSeriesExpiryIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.SeriesExpiryPadding = _data.GetU64(offset);
                offset += 8;
                result.Positions = new Position[46];
                for (uint resultPositionsIdx = 0; resultPositionsIdx < 46; resultPositionsIdx++)
                {
                    offset += Position.Deserialize(_data, offset, out var resultPositionsresultPositionsIdx);
                    result.Positions[resultPositionsIdx] = resultPositionsresultPositionsIdx;
                }

                result.PositionsPadding = new Position[92];
                for (uint resultPositionsPaddingIdx = 0; resultPositionsPaddingIdx < 92; resultPositionsPaddingIdx++)
                {
                    offset += Position.Deserialize(_data, offset, out var resultPositionsPaddingresultPositionsPaddingIdx);
                    result.PositionsPadding[resultPositionsPaddingIdx] = resultPositionsPaddingresultPositionsPaddingIdx;
                }

                result.Asset = (Asset)_data.GetU8(offset);
                offset += 1;
                result.Padding = _data.GetBytes(offset, 262);
                offset += 262;
                return result;
            }
        }

        public partial class MarginAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 17162043574362954885UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{133, 220, 173, 213, 179, 211, 43, 238};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "PPdW8aua6TF";
            public PublicKey Authority { get; set; }

            public byte Nonce { get; set; }

            public ulong Balance { get; set; }

            public bool ForceCancelFlag { get; set; }

            public byte[] OpenOrdersNonce { get; set; }

            public ulong[] SeriesExpiry { get; set; }

            public ulong SeriesExpiryPadding { get; set; }

            public ProductLedger[] ProductLedgers { get; set; }

            public ProductLedger[] ProductLedgersPadding { get; set; }

            public ProductLedger PerpProductLedger { get; set; }

            public long RebalanceAmount { get; set; }

            public Asset Asset { get; set; }

            public MarginAccountType AccountType { get; set; }

            public AnchorDecimal LastFundingDelta { get; set; }

            public byte[] Padding { get; set; }

            public static MarginAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                MarginAccount result = new MarginAccount();
                result.Authority = _data.GetPubKey(offset);
                offset += 32;
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Balance = _data.GetU64(offset);
                offset += 8;
                result.ForceCancelFlag = _data.GetBool(offset);
                offset += 1;
                result.OpenOrdersNonce = _data.GetBytes(offset, 138);
                offset += 138;
                result.SeriesExpiry = new ulong[5];
                for (uint resultSeriesExpiryIdx = 0; resultSeriesExpiryIdx < 5; resultSeriesExpiryIdx++)
                {
                    result.SeriesExpiry[resultSeriesExpiryIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.SeriesExpiryPadding = _data.GetU64(offset);
                offset += 8;
                result.ProductLedgers = new ProductLedger[46];
                for (uint resultProductLedgersIdx = 0; resultProductLedgersIdx < 46; resultProductLedgersIdx++)
                {
                    offset += ProductLedger.Deserialize(_data, offset, out var resultProductLedgersresultProductLedgersIdx);
                    result.ProductLedgers[resultProductLedgersIdx] = resultProductLedgersresultProductLedgersIdx;
                }

                result.ProductLedgersPadding = new ProductLedger[91];
                for (uint resultProductLedgersPaddingIdx = 0; resultProductLedgersPaddingIdx < 91; resultProductLedgersPaddingIdx++)
                {
                    offset += ProductLedger.Deserialize(_data, offset, out var resultProductLedgersPaddingresultProductLedgersPaddingIdx);
                    result.ProductLedgersPadding[resultProductLedgersPaddingIdx] = resultProductLedgersPaddingresultProductLedgersPaddingIdx;
                }

                offset += ProductLedger.Deserialize(_data, offset, out var resultPerpProductLedger);
                result.PerpProductLedger = resultPerpProductLedger;
                result.RebalanceAmount = _data.GetS64(offset);
                offset += 8;
                result.Asset = (Asset)_data.GetU8(offset);
                offset += 1;
                result.AccountType = (MarginAccountType)_data.GetU8(offset);
                offset += 1;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultLastFundingDelta);
                result.LastFundingDelta = resultLastFundingDelta;
                result.Padding = _data.GetBytes(offset, 370);
                offset += 370;
                return result;
            }
        }

        public partial class SocializedLossAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 9901256401400757825UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{65, 254, 141, 235, 60, 84, 104, 137};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "C3EDdUtBKdz";
            public byte Nonce { get; set; }

            public ulong OverbankruptAmount { get; set; }

            public static SocializedLossAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                SocializedLossAccount result = new SocializedLossAccount();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.OverbankruptAmount = _data.GetU64(offset);
                offset += 8;
                return result;
            }
        }

        public partial class WhitelistDepositAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 15670466511889826414UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{110, 2, 217, 81, 68, 174, 120, 217};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "KQFFiAXbT1a";
            public byte Nonce { get; set; }

            public PublicKey UserKey { get; set; }

            public static WhitelistDepositAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                WhitelistDepositAccount result = new WhitelistDepositAccount();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.UserKey = _data.GetPubKey(offset);
                offset += 32;
                return result;
            }
        }

        public partial class WhitelistInsuranceAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 155440715311114250UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{10, 104, 192, 203, 129, 60, 40, 2};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "2jyy7x7DwFX";
            public byte Nonce { get; set; }

            public PublicKey UserKey { get; set; }

            public static WhitelistInsuranceAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                WhitelistInsuranceAccount result = new WhitelistInsuranceAccount();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.UserKey = _data.GetPubKey(offset);
                offset += 32;
                return result;
            }
        }

        public partial class InsuranceDepositAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 13316477224568529334UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{182, 161, 252, 101, 123, 161, 205, 184};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "XYmTaq8Gph5";
            public byte Nonce { get; set; }

            public ulong Amount { get; set; }

            public static InsuranceDepositAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                InsuranceDepositAccount result = new InsuranceDepositAccount();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Amount = _data.GetU64(offset);
                offset += 8;
                return result;
            }
        }

        public partial class WhitelistTradingFeesAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 17245676645641955291UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{219, 39, 189, 166, 137, 243, 84, 239};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "df5fEGedh8i";
            public byte Nonce { get; set; }

            public PublicKey UserKey { get; set; }

            public static WhitelistTradingFeesAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                WhitelistTradingFeesAccount result = new WhitelistTradingFeesAccount();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.UserKey = _data.GetPubKey(offset);
                offset += 32;
                return result;
            }
        }

        public partial class ReferrerAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 668463814603182896UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{48, 19, 160, 54, 76, 220, 70, 9};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "93QRaaYRAdE";
            public byte Nonce { get; set; }

            public bool HasAlias { get; set; }

            public PublicKey Referrer { get; set; }

            public ulong PendingRewards { get; set; }

            public ulong ClaimedRewards { get; set; }

            public static ReferrerAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                ReferrerAccount result = new ReferrerAccount();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.HasAlias = _data.GetBool(offset);
                offset += 1;
                result.Referrer = _data.GetPubKey(offset);
                offset += 32;
                result.PendingRewards = _data.GetU64(offset);
                offset += 8;
                result.ClaimedRewards = _data.GetU64(offset);
                offset += 8;
                return result;
            }
        }

        public partial class ReferralAccount
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 169986440293294829UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{237, 162, 80, 78, 196, 233, 91, 2};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "gkMB8n8KczD";
            public byte Nonce { get; set; }

            public PublicKey Referrer { get; set; }

            public PublicKey User { get; set; }

            public ulong Timestamp { get; set; }

            public ulong PendingRewards { get; set; }

            public ulong ClaimedRewards { get; set; }

            public static ReferralAccount Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                ReferralAccount result = new ReferralAccount();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Referrer = _data.GetPubKey(offset);
                offset += 32;
                result.User = _data.GetPubKey(offset);
                offset += 32;
                result.Timestamp = _data.GetU64(offset);
                offset += 8;
                result.PendingRewards = _data.GetU64(offset);
                offset += 8;
                result.ClaimedRewards = _data.GetU64(offset);
                offset += 8;
                return result;
            }
        }

        public partial class ReferrerAlias
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 4232986892940764551UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{135, 101, 158, 220, 38, 151, 190, 58};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "PeXAX83RUKT";
            public byte Nonce { get; set; }

            public byte[] Alias { get; set; }

            public PublicKey Referrer { get; set; }

            public static ReferrerAlias Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                ReferrerAlias result = new ReferrerAlias();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Alias = _data.GetBytes(offset, 15);
                offset += 15;
                result.Referrer = _data.GetPubKey(offset);
                offset += 32;
                return result;
            }
        }
    }

    namespace Errors
    {
        public enum ZetaErrorKind : uint
        {
            DepositOverflow = 6000U,
            Unreachable = 6001U,
            FailedInitialMarginRequirement = 6002U,
            LiquidatorFailedMarginRequirement = 6003U,
            CannotLiquidateOwnAccount = 6004U,
            CrankInvalidRemainingAccounts = 6005U,
            IncorrectTickSize = 6006U,
            ZeroPrice = 6007U,
            ZeroSize = 6008U,
            ZeroWithdrawableBalance = 6009U,
            DepositAmountExceeded = 6010U,
            WithdrawalAmountExceedsWithdrawableBalance = 6011U,
            AccountHasSufficientMarginPostCancels = 6012U,
            OverBankrupt = 6013U,
            AccountHasSufficientMargin = 6014U,
            UserHasNoActiveOrders = 6015U,
            InvalidExpirationInterval = 6016U,
            ProductMarketsAlreadyInitialized = 6017U,
            InvalidProductMarketKey = 6018U,
            MarketNotLive = 6019U,
            MarketPricingNotReady = 6020U,
            UserHasRemainingOrdersOnExpiredMarket = 6021U,
            InvalidSeriesExpiration = 6022U,
            InvalidExpiredOrderCancel = 6023U,
            NoMarketsToAdd = 6024U,
            UserHasUnsettledPositions = 6025U,
            NoMarginAccountsToSettle = 6026U,
            CannotSettleUserWithActiveOrders = 6027U,
            OrderbookNotEmpty = 6028U,
            InvalidNumberOfAccounts = 6029U,
            InvalidMarketAccounts = 6030U,
            ProductStrikeUninitialized = 6031U,
            PricingNotUpToDate = 6032U,
            RetreatsAreStale = 6033U,
            ProductDirty = 6034U,
            ProductStrikesInitialized = 6035U,
            StrikeInitializationNotReady = 6036U,
            UnsupportedKind = 6037U,
            InvalidZetaGroup = 6038U,
            InvalidMarginAccount = 6039U,
            InvalidGreeksAccount = 6040U,
            InvalidSettlementAccount = 6041U,
            InvalidCancelAuthority = 6042U,
            CannotUpdatePricingAfterExpiry = 6043U,
            LoadAccountDiscriminatorAlreadySet = 6044U,
            AccountAlreadyInitialized = 6045U,
            GreeksAccountSeedsMismatch = 6046U,
            ZetaGroupAccountSeedsMismatch = 6047U,
            MarginAccountSeedsMismatch = 6048U,
            OpenOrdersAccountSeedsMismatch = 6049U,
            MarketNodeAccountSeedsMismatch = 6050U,
            UserTradingFeeWhitelistAccountSeedsMismatch = 6051U,
            UserDepositWhitelistAccountSeedsMismatch = 6052U,
            MarketIndexesUninitialized = 6053U,
            MarketIndexesAlreadyInitialized = 6054U,
            CannotGetUnsetStrike = 6055U,
            CannotSetInitializedStrike = 6056U,
            CannotResetUninitializedStrike = 6057U,
            CrankMarginAccountNotMutable = 6058U,
            InvalidAdminSigner = 6059U,
            UserHasActiveOrders = 6060U,
            UserForceCancelInProgress = 6061U,
            FailedPriceBandCheck = 6062U,
            UnsortedOpenOrdersAccounts = 6063U,
            AccountNotMutable = 6064U,
            AccountDiscriminatorMismatch = 6065U,
            InvalidMarketNodeIndex = 6066U,
            InvalidMarketNode = 6067U,
            LUTOutOfBounds = 6068U,
            RebalanceInsuranceInvalidRemainingAccounts = 6069U,
            InvalidMintDecimals = 6070U,
            InvalidZetaGroupOracle = 6071U,
            InvalidZetaGroupDepositMint = 6072U,
            InvalidZetaGroupRebalanceMint = 6073U,
            InvalidDepositAmount = 6074U,
            InvalidTokenAccountOwner = 6075U,
            InvalidWithdrawAmount = 6076U,
            InvalidDepositRemainingAccounts = 6077U,
            InvalidPlaceOrderRemainingAccounts = 6078U,
            ClientOrderIdCannotBeZero = 6079U,
            ZetaGroupHalted = 6080U,
            ZetaGroupNotHalted = 6081U,
            HaltMarkPriceNotSet = 6082U,
            HaltMarketsNotCleaned = 6083U,
            HaltMarketNodesNotCleaned = 6084U,
            CannotExpireOptionsAfterExpirationThreshold = 6085U,
            PostOnlyInCross = 6086U,
            FillOrKillNotFullSize = 6087U,
            InvalidOpenOrdersMapOwner = 6088U,
            AccountDidNotSerialize = 6089U,
            OpenOrdersWithNonEmptyPositions = 6090U,
            CannotCloseNonEmptyMarginAccount = 6091U,
            InvalidTagLength = 6092U,
            NakedShortCallIsNotAllowed = 6093U,
            InvalidSpreadAccount = 6094U,
            CannotCloseNonEmptySpreadAccount = 6095U,
            SpreadAccountSeedsMismatch = 6096U,
            SpreadAccountHasUnsettledPositions = 6097U,
            SpreadAccountInvalidExpirySeriesState = 6098U,
            InsufficientFundsToCollateralizeSpreadAccount = 6099U,
            FailedMaintenanceMarginRequirement = 6100U,
            InvalidMovement = 6101U,
            MovementOnExpiredSeries = 6102U,
            InvalidMovementSize = 6103U,
            ExceededMaxPositionMovements = 6104U,
            ExceededMaxSpreadAccountContracts = 6105U,
            OraclePriceIsInvalid = 6106U,
            InvalidUnderlyingMint = 6107U,
            InvalidReferrerAlias = 6108U,
            ReferrerAlreadyHasAlias = 6109U,
            InvalidTreasuryMovementAmount = 6110U,
            InvalidReferralsAdminSigner = 6111U,
            InvalidSetReferralsRewardsRemainingAccounts = 6112U,
            SetReferralsRewardsAccountNotMutable = 6113U,
            InvalidClaimReferralsRewardsAmount = 6114U,
            InvalidClaimReferralsRewardsAccount = 6115U,
            ReferralAccountSeedsMismatch = 6116U,
            ReferrerAccountSeedsMismatch = 6117U,
            ProtectedMmMarginAccount = 6118U,
            CannotWithdrawWithOpenOrders = 6119U,
            FundingRateNotUpToDate = 6120U,
            PerpSyncQueueFull = 6121U,
            PerpSyncQueueAccountSeedsMismatch = 6122U,
            PerpSyncQueueEmpty = 6123U,
            InvalidNonPerpMarket = 6124U,
            InvalidPerpMarket = 6125U,
            CannotInitializePerpMarketNode = 6126U,
            DeprecatedInstruction = 6127U
        }
    }

    namespace Events
    {
    }

    namespace Types
    {
        public partial class ProductGreeks
        {
            public ulong Delta { get; set; }

            public AnchorDecimal Vega { get; set; }

            public AnchorDecimal Volatility { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU64(Delta, offset);
                offset += 8;
                offset += Vega.Serialize(_data, offset);
                offset += Volatility.Serialize(_data, offset);
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out ProductGreeks result)
            {
                int offset = initialOffset;
                result = new ProductGreeks();
                result.Delta = _data.GetU64(offset);
                offset += 8;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultVega);
                result.Vega = resultVega;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultVolatility);
                result.Volatility = resultVolatility;
                return offset - initialOffset;
            }
        }

        public partial class AnchorDecimal
        {
            public uint Flags { get; set; }

            public uint Hi { get; set; }

            public uint Lo { get; set; }

            public uint Mid { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU32(Flags, offset);
                offset += 4;
                _data.WriteU32(Hi, offset);
                offset += 4;
                _data.WriteU32(Lo, offset);
                offset += 4;
                _data.WriteU32(Mid, offset);
                offset += 4;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out AnchorDecimal result)
            {
                int offset = initialOffset;
                result = new AnchorDecimal();
                result.Flags = _data.GetU32(offset);
                offset += 4;
                result.Hi = _data.GetU32(offset);
                offset += 4;
                result.Lo = _data.GetU32(offset);
                offset += 4;
                result.Mid = _data.GetU32(offset);
                offset += 4;
                return offset - initialOffset;
            }
        }

        public partial class HaltState
        {
            public bool Halted { get; set; }

            public ulong SpotPrice { get; set; }

            public ulong Timestamp { get; set; }

            public bool[] MarkPricesSet { get; set; }

            public bool[] MarkPricesSetPadding { get; set; }

            public bool PerpMarkPriceSet { get; set; }

            public bool[] MarketNodesCleaned { get; set; }

            public bool[] MarketNodesCleanedPadding { get; set; }

            public bool[] MarketCleaned { get; set; }

            public bool[] MarketCleanedPadding { get; set; }

            public bool PerpMarketCleaned { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteBool(Halted, offset);
                offset += 1;
                _data.WriteU64(SpotPrice, offset);
                offset += 8;
                _data.WriteU64(Timestamp, offset);
                offset += 8;
                foreach (var markPricesSetElement in MarkPricesSet)
                {
                    _data.WriteBool(markPricesSetElement, offset);
                    offset += 1;
                }

                foreach (var markPricesSetPaddingElement in MarkPricesSetPadding)
                {
                    _data.WriteBool(markPricesSetPaddingElement, offset);
                    offset += 1;
                }

                _data.WriteBool(PerpMarkPriceSet, offset);
                offset += 1;
                foreach (var marketNodesCleanedElement in MarketNodesCleaned)
                {
                    _data.WriteBool(marketNodesCleanedElement, offset);
                    offset += 1;
                }

                foreach (var marketNodesCleanedPaddingElement in MarketNodesCleanedPadding)
                {
                    _data.WriteBool(marketNodesCleanedPaddingElement, offset);
                    offset += 1;
                }

                foreach (var marketCleanedElement in MarketCleaned)
                {
                    _data.WriteBool(marketCleanedElement, offset);
                    offset += 1;
                }

                foreach (var marketCleanedPaddingElement in MarketCleanedPadding)
                {
                    _data.WriteBool(marketCleanedPaddingElement, offset);
                    offset += 1;
                }

                _data.WriteBool(PerpMarketCleaned, offset);
                offset += 1;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out HaltState result)
            {
                int offset = initialOffset;
                result = new HaltState();
                result.Halted = _data.GetBool(offset);
                offset += 1;
                result.SpotPrice = _data.GetU64(offset);
                offset += 8;
                result.Timestamp = _data.GetU64(offset);
                offset += 8;
                result.MarkPricesSet = new bool[2];
                for (uint resultMarkPricesSetIdx = 0; resultMarkPricesSetIdx < 2; resultMarkPricesSetIdx++)
                {
                    result.MarkPricesSet[resultMarkPricesSetIdx] = _data.GetBool(offset);
                    offset += 1;
                }

                result.MarkPricesSetPadding = new bool[3];
                for (uint resultMarkPricesSetPaddingIdx = 0; resultMarkPricesSetPaddingIdx < 3; resultMarkPricesSetPaddingIdx++)
                {
                    result.MarkPricesSetPadding[resultMarkPricesSetPaddingIdx] = _data.GetBool(offset);
                    offset += 1;
                }

                result.PerpMarkPriceSet = _data.GetBool(offset);
                offset += 1;
                result.MarketNodesCleaned = new bool[2];
                for (uint resultMarketNodesCleanedIdx = 0; resultMarketNodesCleanedIdx < 2; resultMarketNodesCleanedIdx++)
                {
                    result.MarketNodesCleaned[resultMarketNodesCleanedIdx] = _data.GetBool(offset);
                    offset += 1;
                }

                result.MarketNodesCleanedPadding = new bool[4];
                for (uint resultMarketNodesCleanedPaddingIdx = 0; resultMarketNodesCleanedPaddingIdx < 4; resultMarketNodesCleanedPaddingIdx++)
                {
                    result.MarketNodesCleanedPadding[resultMarketNodesCleanedPaddingIdx] = _data.GetBool(offset);
                    offset += 1;
                }

                result.MarketCleaned = new bool[46];
                for (uint resultMarketCleanedIdx = 0; resultMarketCleanedIdx < 46; resultMarketCleanedIdx++)
                {
                    result.MarketCleaned[resultMarketCleanedIdx] = _data.GetBool(offset);
                    offset += 1;
                }

                result.MarketCleanedPadding = new bool[91];
                for (uint resultMarketCleanedPaddingIdx = 0; resultMarketCleanedPaddingIdx < 91; resultMarketCleanedPaddingIdx++)
                {
                    result.MarketCleanedPadding[resultMarketCleanedPaddingIdx] = _data.GetBool(offset);
                    offset += 1;
                }

                result.PerpMarketCleaned = _data.GetBool(offset);
                offset += 1;
                return offset - initialOffset;
            }
        }

        public partial class PricingParameters
        {
            public AnchorDecimal OptionTradeNormalizer { get; set; }

            public AnchorDecimal FutureTradeNormalizer { get; set; }

            public AnchorDecimal MaxVolatilityRetreat { get; set; }

            public AnchorDecimal MaxInterestRetreat { get; set; }

            public ulong MaxDelta { get; set; }

            public ulong MinDelta { get; set; }

            public ulong MinVolatility { get; set; }

            public ulong MaxVolatility { get; set; }

            public long MinInterestRate { get; set; }

            public long MaxInterestRate { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                offset += OptionTradeNormalizer.Serialize(_data, offset);
                offset += FutureTradeNormalizer.Serialize(_data, offset);
                offset += MaxVolatilityRetreat.Serialize(_data, offset);
                offset += MaxInterestRetreat.Serialize(_data, offset);
                _data.WriteU64(MaxDelta, offset);
                offset += 8;
                _data.WriteU64(MinDelta, offset);
                offset += 8;
                _data.WriteU64(MinVolatility, offset);
                offset += 8;
                _data.WriteU64(MaxVolatility, offset);
                offset += 8;
                _data.WriteS64(MinInterestRate, offset);
                offset += 8;
                _data.WriteS64(MaxInterestRate, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PricingParameters result)
            {
                int offset = initialOffset;
                result = new PricingParameters();
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultOptionTradeNormalizer);
                result.OptionTradeNormalizer = resultOptionTradeNormalizer;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultFutureTradeNormalizer);
                result.FutureTradeNormalizer = resultFutureTradeNormalizer;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultMaxVolatilityRetreat);
                result.MaxVolatilityRetreat = resultMaxVolatilityRetreat;
                offset += AnchorDecimal.Deserialize(_data, offset, out var resultMaxInterestRetreat);
                result.MaxInterestRetreat = resultMaxInterestRetreat;
                result.MaxDelta = _data.GetU64(offset);
                offset += 8;
                result.MinDelta = _data.GetU64(offset);
                offset += 8;
                result.MinVolatility = _data.GetU64(offset);
                offset += 8;
                result.MaxVolatility = _data.GetU64(offset);
                offset += 8;
                result.MinInterestRate = _data.GetS64(offset);
                offset += 8;
                result.MaxInterestRate = _data.GetS64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class MarginParameters
        {
            public ulong FutureMarginInitial { get; set; }

            public ulong FutureMarginMaintenance { get; set; }

            public ulong OptionMarkPercentageLongInitial { get; set; }

            public ulong OptionSpotPercentageLongInitial { get; set; }

            public ulong OptionSpotPercentageShortInitial { get; set; }

            public ulong OptionDynamicPercentageShortInitial { get; set; }

            public ulong OptionMarkPercentageLongMaintenance { get; set; }

            public ulong OptionSpotPercentageLongMaintenance { get; set; }

            public ulong OptionSpotPercentageShortMaintenance { get; set; }

            public ulong OptionDynamicPercentageShortMaintenance { get; set; }

            public ulong OptionShortPutCapPercentage { get; set; }

            public byte[] Padding { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU64(FutureMarginInitial, offset);
                offset += 8;
                _data.WriteU64(FutureMarginMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionMarkPercentageLongInitial, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageLongInitial, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageShortInitial, offset);
                offset += 8;
                _data.WriteU64(OptionDynamicPercentageShortInitial, offset);
                offset += 8;
                _data.WriteU64(OptionMarkPercentageLongMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageLongMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageShortMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionDynamicPercentageShortMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionShortPutCapPercentage, offset);
                offset += 8;
                _data.WriteSpan(Padding, offset);
                offset += Padding.Length;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out MarginParameters result)
            {
                int offset = initialOffset;
                result = new MarginParameters();
                result.FutureMarginInitial = _data.GetU64(offset);
                offset += 8;
                result.FutureMarginMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionMarkPercentageLongInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageLongInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageShortInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionDynamicPercentageShortInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionMarkPercentageLongMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageLongMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageShortMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionDynamicPercentageShortMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionShortPutCapPercentage = _data.GetU64(offset);
                offset += 8;
                result.Padding = _data.GetBytes(offset, 32);
                offset += 32;
                return offset - initialOffset;
            }
        }

        public partial class PerpParameters
        {
            public long MinFundingRatePercent { get; set; }

            public long MaxFundingRatePercent { get; set; }

            public ulong ImpactCashDelta { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteS64(MinFundingRatePercent, offset);
                offset += 8;
                _data.WriteS64(MaxFundingRatePercent, offset);
                offset += 8;
                _data.WriteU64(ImpactCashDelta, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PerpParameters result)
            {
                int offset = initialOffset;
                result = new PerpParameters();
                result.MinFundingRatePercent = _data.GetS64(offset);
                offset += 8;
                result.MaxFundingRatePercent = _data.GetS64(offset);
                offset += 8;
                result.ImpactCashDelta = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class ExpirySeries
        {
            public ulong ActiveTs { get; set; }

            public ulong ExpiryTs { get; set; }

            public bool Dirty { get; set; }

            public byte[] Padding { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU64(ActiveTs, offset);
                offset += 8;
                _data.WriteU64(ExpiryTs, offset);
                offset += 8;
                _data.WriteBool(Dirty, offset);
                offset += 1;
                _data.WriteSpan(Padding, offset);
                offset += Padding.Length;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out ExpirySeries result)
            {
                int offset = initialOffset;
                result = new ExpirySeries();
                result.ActiveTs = _data.GetU64(offset);
                offset += 8;
                result.ExpiryTs = _data.GetU64(offset);
                offset += 8;
                result.Dirty = _data.GetBool(offset);
                offset += 1;
                result.Padding = _data.GetBytes(offset, 15);
                offset += 15;
                return offset - initialOffset;
            }
        }

        public partial class Strike
        {
            public bool IsSet { get; set; }

            public ulong Value { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteBool(IsSet, offset);
                offset += 1;
                _data.WriteU64(Value, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Strike result)
            {
                int offset = initialOffset;
                result = new Strike();
                result.IsSet = _data.GetBool(offset);
                offset += 1;
                result.Value = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class Product
        {
            public PublicKey Market { get; set; }

            public Strike Strike { get; set; }

            public bool Dirty { get; set; }

            public Kind Kind { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WritePubKey(Market, offset);
                offset += 32;
                offset += Strike.Serialize(_data, offset);
                _data.WriteBool(Dirty, offset);
                offset += 1;
                _data.WriteU8((byte)Kind, offset);
                offset += 1;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Product result)
            {
                int offset = initialOffset;
                result = new Product();
                result.Market = _data.GetPubKey(offset);
                offset += 32;
                offset += Strike.Deserialize(_data, offset, out var resultStrike);
                result.Strike = resultStrike;
                result.Dirty = _data.GetBool(offset);
                offset += 1;
                result.Kind = (Kind)_data.GetU8(offset);
                offset += 1;
                return offset - initialOffset;
            }
        }

        public partial class Position
        {
            public long Size { get; set; }

            public ulong CostOfTrades { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteS64(Size, offset);
                offset += 8;
                _data.WriteU64(CostOfTrades, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Position result)
            {
                int offset = initialOffset;
                result = new Position();
                result.Size = _data.GetS64(offset);
                offset += 8;
                result.CostOfTrades = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class OrderState
        {
            public ulong ClosingOrders { get; set; }

            public ulong[] OpeningOrders { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU64(ClosingOrders, offset);
                offset += 8;
                foreach (var openingOrdersElement in OpeningOrders)
                {
                    _data.WriteU64(openingOrdersElement, offset);
                    offset += 8;
                }

                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out OrderState result)
            {
                int offset = initialOffset;
                result = new OrderState();
                result.ClosingOrders = _data.GetU64(offset);
                offset += 8;
                result.OpeningOrders = new ulong[2];
                for (uint resultOpeningOrdersIdx = 0; resultOpeningOrdersIdx < 2; resultOpeningOrdersIdx++)
                {
                    result.OpeningOrders[resultOpeningOrdersIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                return offset - initialOffset;
            }
        }

        public partial class ProductLedger
        {
            public Position Position { get; set; }

            public OrderState OrderState { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                offset += Position.Serialize(_data, offset);
                offset += OrderState.Serialize(_data, offset);
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out ProductLedger result)
            {
                int offset = initialOffset;
                result = new ProductLedger();
                offset += Position.Deserialize(_data, offset, out var resultPosition);
                result.Position = resultPosition;
                offset += OrderState.Deserialize(_data, offset, out var resultOrderState);
                result.OrderState = resultOrderState;
                return offset - initialOffset;
            }
        }

        public partial class HaltZetaGroupArgs
        {
            public ulong SpotPrice { get; set; }

            public ulong Timestamp { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU64(SpotPrice, offset);
                offset += 8;
                _data.WriteU64(Timestamp, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out HaltZetaGroupArgs result)
            {
                int offset = initialOffset;
                result = new HaltZetaGroupArgs();
                result.SpotPrice = _data.GetU64(offset);
                offset += 8;
                result.Timestamp = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class UpdateVolatilityArgs
        {
            public byte ExpiryIndex { get; set; }

            public ulong[] Volatility { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(ExpiryIndex, offset);
                offset += 1;
                foreach (var volatilityElement in Volatility)
                {
                    _data.WriteU64(volatilityElement, offset);
                    offset += 8;
                }

                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateVolatilityArgs result)
            {
                int offset = initialOffset;
                result = new UpdateVolatilityArgs();
                result.ExpiryIndex = _data.GetU8(offset);
                offset += 1;
                result.Volatility = new ulong[5];
                for (uint resultVolatilityIdx = 0; resultVolatilityIdx < 5; resultVolatilityIdx++)
                {
                    result.Volatility[resultVolatilityIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                return offset - initialOffset;
            }
        }

        public partial class UpdateInterestRateArgs
        {
            public byte ExpiryIndex { get; set; }

            public long InterestRate { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(ExpiryIndex, offset);
                offset += 1;
                _data.WriteS64(InterestRate, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateInterestRateArgs result)
            {
                int offset = initialOffset;
                result = new UpdateInterestRateArgs();
                result.ExpiryIndex = _data.GetU8(offset);
                offset += 1;
                result.InterestRate = _data.GetS64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class SetReferralsRewardsArgs
        {
            public PublicKey ReferralsAccountKey { get; set; }

            public ulong PendingRewards { get; set; }

            public bool Overwrite { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WritePubKey(ReferralsAccountKey, offset);
                offset += 32;
                _data.WriteU64(PendingRewards, offset);
                offset += 8;
                _data.WriteBool(Overwrite, offset);
                offset += 1;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SetReferralsRewardsArgs result)
            {
                int offset = initialOffset;
                result = new SetReferralsRewardsArgs();
                result.ReferralsAccountKey = _data.GetPubKey(offset);
                offset += 32;
                result.PendingRewards = _data.GetU64(offset);
                offset += 8;
                result.Overwrite = _data.GetBool(offset);
                offset += 1;
                return offset - initialOffset;
            }
        }

        public partial class ExpireSeriesOverrideArgs
        {
            public byte SettlementNonce { get; set; }

            public ulong SettlementPrice { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(SettlementNonce, offset);
                offset += 1;
                _data.WriteU64(SettlementPrice, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out ExpireSeriesOverrideArgs result)
            {
                int offset = initialOffset;
                result = new ExpireSeriesOverrideArgs();
                result.SettlementNonce = _data.GetU8(offset);
                offset += 1;
                result.SettlementPrice = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class InitializeMarketArgs
        {
            public byte Index { get; set; }

            public byte MarketNonce { get; set; }

            public byte BaseMintNonce { get; set; }

            public byte QuoteMintNonce { get; set; }

            public byte ZetaBaseVaultNonce { get; set; }

            public byte ZetaQuoteVaultNonce { get; set; }

            public byte DexBaseVaultNonce { get; set; }

            public byte DexQuoteVaultNonce { get; set; }

            public ulong VaultSignerNonce { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(Index, offset);
                offset += 1;
                _data.WriteU8(MarketNonce, offset);
                offset += 1;
                _data.WriteU8(BaseMintNonce, offset);
                offset += 1;
                _data.WriteU8(QuoteMintNonce, offset);
                offset += 1;
                _data.WriteU8(ZetaBaseVaultNonce, offset);
                offset += 1;
                _data.WriteU8(ZetaQuoteVaultNonce, offset);
                offset += 1;
                _data.WriteU8(DexBaseVaultNonce, offset);
                offset += 1;
                _data.WriteU8(DexQuoteVaultNonce, offset);
                offset += 1;
                _data.WriteU64(VaultSignerNonce, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out InitializeMarketArgs result)
            {
                int offset = initialOffset;
                result = new InitializeMarketArgs();
                result.Index = _data.GetU8(offset);
                offset += 1;
                result.MarketNonce = _data.GetU8(offset);
                offset += 1;
                result.BaseMintNonce = _data.GetU8(offset);
                offset += 1;
                result.QuoteMintNonce = _data.GetU8(offset);
                offset += 1;
                result.ZetaBaseVaultNonce = _data.GetU8(offset);
                offset += 1;
                result.ZetaQuoteVaultNonce = _data.GetU8(offset);
                offset += 1;
                result.DexBaseVaultNonce = _data.GetU8(offset);
                offset += 1;
                result.DexQuoteVaultNonce = _data.GetU8(offset);
                offset += 1;
                result.VaultSignerNonce = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class InitializeStateArgs
        {
            public byte StateNonce { get; set; }

            public byte SerumNonce { get; set; }

            public byte MintAuthNonce { get; set; }

            public uint StrikeInitializationThresholdSeconds { get; set; }

            public uint PricingFrequencySeconds { get; set; }

            public uint LiquidatorLiquidationPercentage { get; set; }

            public uint InsuranceVaultLiquidationPercentage { get; set; }

            public ulong NativeD1TradeFeePercentage { get; set; }

            public ulong NativeD1UnderlyingFeePercentage { get; set; }

            public ulong NativeOptionTradeFeePercentage { get; set; }

            public ulong NativeOptionUnderlyingFeePercentage { get; set; }

            public ulong NativeWhitelistUnderlyingFeePercentage { get; set; }

            public ulong NativeDepositLimit { get; set; }

            public uint ExpirationThresholdSeconds { get; set; }

            public byte PositionMovementFeeBps { get; set; }

            public byte MarginConcessionPercentage { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(StateNonce, offset);
                offset += 1;
                _data.WriteU8(SerumNonce, offset);
                offset += 1;
                _data.WriteU8(MintAuthNonce, offset);
                offset += 1;
                _data.WriteU32(StrikeInitializationThresholdSeconds, offset);
                offset += 4;
                _data.WriteU32(PricingFrequencySeconds, offset);
                offset += 4;
                _data.WriteU32(LiquidatorLiquidationPercentage, offset);
                offset += 4;
                _data.WriteU32(InsuranceVaultLiquidationPercentage, offset);
                offset += 4;
                _data.WriteU64(NativeD1TradeFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeD1UnderlyingFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeOptionTradeFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeOptionUnderlyingFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeWhitelistUnderlyingFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeDepositLimit, offset);
                offset += 8;
                _data.WriteU32(ExpirationThresholdSeconds, offset);
                offset += 4;
                _data.WriteU8(PositionMovementFeeBps, offset);
                offset += 1;
                _data.WriteU8(MarginConcessionPercentage, offset);
                offset += 1;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out InitializeStateArgs result)
            {
                int offset = initialOffset;
                result = new InitializeStateArgs();
                result.StateNonce = _data.GetU8(offset);
                offset += 1;
                result.SerumNonce = _data.GetU8(offset);
                offset += 1;
                result.MintAuthNonce = _data.GetU8(offset);
                offset += 1;
                result.StrikeInitializationThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                result.PricingFrequencySeconds = _data.GetU32(offset);
                offset += 4;
                result.LiquidatorLiquidationPercentage = _data.GetU32(offset);
                offset += 4;
                result.InsuranceVaultLiquidationPercentage = _data.GetU32(offset);
                offset += 4;
                result.NativeD1TradeFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeD1UnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeOptionTradeFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeOptionUnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeWhitelistUnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeDepositLimit = _data.GetU64(offset);
                offset += 8;
                result.ExpirationThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                result.PositionMovementFeeBps = _data.GetU8(offset);
                offset += 1;
                result.MarginConcessionPercentage = _data.GetU8(offset);
                offset += 1;
                return offset - initialOffset;
            }
        }

        public partial class InitializeMarketNodeArgs
        {
            public byte Nonce { get; set; }

            public byte Index { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(Nonce, offset);
                offset += 1;
                _data.WriteU8(Index, offset);
                offset += 1;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out InitializeMarketNodeArgs result)
            {
                int offset = initialOffset;
                result = new InitializeMarketNodeArgs();
                result.Nonce = _data.GetU8(offset);
                offset += 1;
                result.Index = _data.GetU8(offset);
                offset += 1;
                return offset - initialOffset;
            }
        }

        public partial class OverrideExpiryArgs
        {
            public byte ExpiryIndex { get; set; }

            public ulong ActiveTs { get; set; }

            public ulong ExpiryTs { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(ExpiryIndex, offset);
                offset += 1;
                _data.WriteU64(ActiveTs, offset);
                offset += 8;
                _data.WriteU64(ExpiryTs, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out OverrideExpiryArgs result)
            {
                int offset = initialOffset;
                result = new OverrideExpiryArgs();
                result.ExpiryIndex = _data.GetU8(offset);
                offset += 1;
                result.ActiveTs = _data.GetU64(offset);
                offset += 8;
                result.ExpiryTs = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class UpdateStateArgs
        {
            public uint StrikeInitializationThresholdSeconds { get; set; }

            public uint PricingFrequencySeconds { get; set; }

            public uint LiquidatorLiquidationPercentage { get; set; }

            public uint InsuranceVaultLiquidationPercentage { get; set; }

            public ulong NativeD1TradeFeePercentage { get; set; }

            public ulong NativeD1UnderlyingFeePercentage { get; set; }

            public ulong NativeOptionTradeFeePercentage { get; set; }

            public ulong NativeOptionUnderlyingFeePercentage { get; set; }

            public ulong NativeWhitelistUnderlyingFeePercentage { get; set; }

            public ulong NativeDepositLimit { get; set; }

            public uint ExpirationThresholdSeconds { get; set; }

            public byte PositionMovementFeeBps { get; set; }

            public byte MarginConcessionPercentage { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU32(StrikeInitializationThresholdSeconds, offset);
                offset += 4;
                _data.WriteU32(PricingFrequencySeconds, offset);
                offset += 4;
                _data.WriteU32(LiquidatorLiquidationPercentage, offset);
                offset += 4;
                _data.WriteU32(InsuranceVaultLiquidationPercentage, offset);
                offset += 4;
                _data.WriteU64(NativeD1TradeFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeD1UnderlyingFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeOptionTradeFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeOptionUnderlyingFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeWhitelistUnderlyingFeePercentage, offset);
                offset += 8;
                _data.WriteU64(NativeDepositLimit, offset);
                offset += 8;
                _data.WriteU32(ExpirationThresholdSeconds, offset);
                offset += 4;
                _data.WriteU8(PositionMovementFeeBps, offset);
                offset += 1;
                _data.WriteU8(MarginConcessionPercentage, offset);
                offset += 1;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateStateArgs result)
            {
                int offset = initialOffset;
                result = new UpdateStateArgs();
                result.StrikeInitializationThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                result.PricingFrequencySeconds = _data.GetU32(offset);
                offset += 4;
                result.LiquidatorLiquidationPercentage = _data.GetU32(offset);
                offset += 4;
                result.InsuranceVaultLiquidationPercentage = _data.GetU32(offset);
                offset += 4;
                result.NativeD1TradeFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeD1UnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeOptionTradeFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeOptionUnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeWhitelistUnderlyingFeePercentage = _data.GetU64(offset);
                offset += 8;
                result.NativeDepositLimit = _data.GetU64(offset);
                offset += 8;
                result.ExpirationThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                result.PositionMovementFeeBps = _data.GetU8(offset);
                offset += 1;
                result.MarginConcessionPercentage = _data.GetU8(offset);
                offset += 1;
                return offset - initialOffset;
            }
        }

        public partial class UpdatePricingParametersArgs
        {
            public ulong OptionTradeNormalizer { get; set; }

            public ulong FutureTradeNormalizer { get; set; }

            public ulong MaxVolatilityRetreat { get; set; }

            public ulong MaxInterestRetreat { get; set; }

            public ulong MinDelta { get; set; }

            public ulong MaxDelta { get; set; }

            public long MinInterestRate { get; set; }

            public long MaxInterestRate { get; set; }

            public ulong MinVolatility { get; set; }

            public ulong MaxVolatility { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU64(OptionTradeNormalizer, offset);
                offset += 8;
                _data.WriteU64(FutureTradeNormalizer, offset);
                offset += 8;
                _data.WriteU64(MaxVolatilityRetreat, offset);
                offset += 8;
                _data.WriteU64(MaxInterestRetreat, offset);
                offset += 8;
                _data.WriteU64(MinDelta, offset);
                offset += 8;
                _data.WriteU64(MaxDelta, offset);
                offset += 8;
                _data.WriteS64(MinInterestRate, offset);
                offset += 8;
                _data.WriteS64(MaxInterestRate, offset);
                offset += 8;
                _data.WriteU64(MinVolatility, offset);
                offset += 8;
                _data.WriteU64(MaxVolatility, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdatePricingParametersArgs result)
            {
                int offset = initialOffset;
                result = new UpdatePricingParametersArgs();
                result.OptionTradeNormalizer = _data.GetU64(offset);
                offset += 8;
                result.FutureTradeNormalizer = _data.GetU64(offset);
                offset += 8;
                result.MaxVolatilityRetreat = _data.GetU64(offset);
                offset += 8;
                result.MaxInterestRetreat = _data.GetU64(offset);
                offset += 8;
                result.MinDelta = _data.GetU64(offset);
                offset += 8;
                result.MaxDelta = _data.GetU64(offset);
                offset += 8;
                result.MinInterestRate = _data.GetS64(offset);
                offset += 8;
                result.MaxInterestRate = _data.GetS64(offset);
                offset += 8;
                result.MinVolatility = _data.GetU64(offset);
                offset += 8;
                result.MaxVolatility = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class UpdateMarginParametersArgs
        {
            public ulong FutureMarginInitial { get; set; }

            public ulong FutureMarginMaintenance { get; set; }

            public ulong OptionMarkPercentageLongInitial { get; set; }

            public ulong OptionSpotPercentageLongInitial { get; set; }

            public ulong OptionSpotPercentageShortInitial { get; set; }

            public ulong OptionDynamicPercentageShortInitial { get; set; }

            public ulong OptionMarkPercentageLongMaintenance { get; set; }

            public ulong OptionSpotPercentageLongMaintenance { get; set; }

            public ulong OptionSpotPercentageShortMaintenance { get; set; }

            public ulong OptionDynamicPercentageShortMaintenance { get; set; }

            public ulong OptionShortPutCapPercentage { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU64(FutureMarginInitial, offset);
                offset += 8;
                _data.WriteU64(FutureMarginMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionMarkPercentageLongInitial, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageLongInitial, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageShortInitial, offset);
                offset += 8;
                _data.WriteU64(OptionDynamicPercentageShortInitial, offset);
                offset += 8;
                _data.WriteU64(OptionMarkPercentageLongMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageLongMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageShortMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionDynamicPercentageShortMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionShortPutCapPercentage, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateMarginParametersArgs result)
            {
                int offset = initialOffset;
                result = new UpdateMarginParametersArgs();
                result.FutureMarginInitial = _data.GetU64(offset);
                offset += 8;
                result.FutureMarginMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionMarkPercentageLongInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageLongInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageShortInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionDynamicPercentageShortInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionMarkPercentageLongMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageLongMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageShortMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionDynamicPercentageShortMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionShortPutCapPercentage = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class UpdatePerpParametersArgs
        {
            public long MinFundingRatePercent { get; set; }

            public long MaxFundingRatePercent { get; set; }

            public ulong PerpImpactCashDelta { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteS64(MinFundingRatePercent, offset);
                offset += 8;
                _data.WriteS64(MaxFundingRatePercent, offset);
                offset += 8;
                _data.WriteU64(PerpImpactCashDelta, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdatePerpParametersArgs result)
            {
                int offset = initialOffset;
                result = new UpdatePerpParametersArgs();
                result.MinFundingRatePercent = _data.GetS64(offset);
                offset += 8;
                result.MaxFundingRatePercent = _data.GetS64(offset);
                offset += 8;
                result.PerpImpactCashDelta = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class InitializeZetaGroupArgs
        {
            public byte ZetaGroupNonce { get; set; }

            public byte UnderlyingNonce { get; set; }

            public byte GreeksNonce { get; set; }

            public byte VaultNonce { get; set; }

            public byte InsuranceVaultNonce { get; set; }

            public byte SocializedLossAccountNonce { get; set; }

            public byte PerpSyncQueueNonce { get; set; }

            public long InterestRate { get; set; }

            public ulong[] Volatility { get; set; }

            public ulong OptionTradeNormalizer { get; set; }

            public ulong FutureTradeNormalizer { get; set; }

            public ulong MaxVolatilityRetreat { get; set; }

            public ulong MaxInterestRetreat { get; set; }

            public ulong MaxDelta { get; set; }

            public ulong MinDelta { get; set; }

            public long MinInterestRate { get; set; }

            public long MaxInterestRate { get; set; }

            public ulong MinVolatility { get; set; }

            public ulong MaxVolatility { get; set; }

            public ulong FutureMarginInitial { get; set; }

            public ulong FutureMarginMaintenance { get; set; }

            public ulong OptionMarkPercentageLongInitial { get; set; }

            public ulong OptionSpotPercentageLongInitial { get; set; }

            public ulong OptionSpotPercentageShortInitial { get; set; }

            public ulong OptionDynamicPercentageShortInitial { get; set; }

            public ulong OptionMarkPercentageLongMaintenance { get; set; }

            public ulong OptionSpotPercentageLongMaintenance { get; set; }

            public ulong OptionSpotPercentageShortMaintenance { get; set; }

            public ulong OptionDynamicPercentageShortMaintenance { get; set; }

            public ulong OptionShortPutCapPercentage { get; set; }

            public uint ExpiryIntervalSeconds { get; set; }

            public uint NewExpiryThresholdSeconds { get; set; }

            public long MinFundingRatePercent { get; set; }

            public long MaxFundingRatePercent { get; set; }

            public ulong PerpImpactCashDelta { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(ZetaGroupNonce, offset);
                offset += 1;
                _data.WriteU8(UnderlyingNonce, offset);
                offset += 1;
                _data.WriteU8(GreeksNonce, offset);
                offset += 1;
                _data.WriteU8(VaultNonce, offset);
                offset += 1;
                _data.WriteU8(InsuranceVaultNonce, offset);
                offset += 1;
                _data.WriteU8(SocializedLossAccountNonce, offset);
                offset += 1;
                _data.WriteU8(PerpSyncQueueNonce, offset);
                offset += 1;
                _data.WriteS64(InterestRate, offset);
                offset += 8;
                foreach (var volatilityElement in Volatility)
                {
                    _data.WriteU64(volatilityElement, offset);
                    offset += 8;
                }

                _data.WriteU64(OptionTradeNormalizer, offset);
                offset += 8;
                _data.WriteU64(FutureTradeNormalizer, offset);
                offset += 8;
                _data.WriteU64(MaxVolatilityRetreat, offset);
                offset += 8;
                _data.WriteU64(MaxInterestRetreat, offset);
                offset += 8;
                _data.WriteU64(MaxDelta, offset);
                offset += 8;
                _data.WriteU64(MinDelta, offset);
                offset += 8;
                _data.WriteS64(MinInterestRate, offset);
                offset += 8;
                _data.WriteS64(MaxInterestRate, offset);
                offset += 8;
                _data.WriteU64(MinVolatility, offset);
                offset += 8;
                _data.WriteU64(MaxVolatility, offset);
                offset += 8;
                _data.WriteU64(FutureMarginInitial, offset);
                offset += 8;
                _data.WriteU64(FutureMarginMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionMarkPercentageLongInitial, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageLongInitial, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageShortInitial, offset);
                offset += 8;
                _data.WriteU64(OptionDynamicPercentageShortInitial, offset);
                offset += 8;
                _data.WriteU64(OptionMarkPercentageLongMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageLongMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionSpotPercentageShortMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionDynamicPercentageShortMaintenance, offset);
                offset += 8;
                _data.WriteU64(OptionShortPutCapPercentage, offset);
                offset += 8;
                _data.WriteU32(ExpiryIntervalSeconds, offset);
                offset += 4;
                _data.WriteU32(NewExpiryThresholdSeconds, offset);
                offset += 4;
                _data.WriteS64(MinFundingRatePercent, offset);
                offset += 8;
                _data.WriteS64(MaxFundingRatePercent, offset);
                offset += 8;
                _data.WriteU64(PerpImpactCashDelta, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out InitializeZetaGroupArgs result)
            {
                int offset = initialOffset;
                result = new InitializeZetaGroupArgs();
                result.ZetaGroupNonce = _data.GetU8(offset);
                offset += 1;
                result.UnderlyingNonce = _data.GetU8(offset);
                offset += 1;
                result.GreeksNonce = _data.GetU8(offset);
                offset += 1;
                result.VaultNonce = _data.GetU8(offset);
                offset += 1;
                result.InsuranceVaultNonce = _data.GetU8(offset);
                offset += 1;
                result.SocializedLossAccountNonce = _data.GetU8(offset);
                offset += 1;
                result.PerpSyncQueueNonce = _data.GetU8(offset);
                offset += 1;
                result.InterestRate = _data.GetS64(offset);
                offset += 8;
                result.Volatility = new ulong[5];
                for (uint resultVolatilityIdx = 0; resultVolatilityIdx < 5; resultVolatilityIdx++)
                {
                    result.Volatility[resultVolatilityIdx] = _data.GetU64(offset);
                    offset += 8;
                }

                result.OptionTradeNormalizer = _data.GetU64(offset);
                offset += 8;
                result.FutureTradeNormalizer = _data.GetU64(offset);
                offset += 8;
                result.MaxVolatilityRetreat = _data.GetU64(offset);
                offset += 8;
                result.MaxInterestRetreat = _data.GetU64(offset);
                offset += 8;
                result.MaxDelta = _data.GetU64(offset);
                offset += 8;
                result.MinDelta = _data.GetU64(offset);
                offset += 8;
                result.MinInterestRate = _data.GetS64(offset);
                offset += 8;
                result.MaxInterestRate = _data.GetS64(offset);
                offset += 8;
                result.MinVolatility = _data.GetU64(offset);
                offset += 8;
                result.MaxVolatility = _data.GetU64(offset);
                offset += 8;
                result.FutureMarginInitial = _data.GetU64(offset);
                offset += 8;
                result.FutureMarginMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionMarkPercentageLongInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageLongInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageShortInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionDynamicPercentageShortInitial = _data.GetU64(offset);
                offset += 8;
                result.OptionMarkPercentageLongMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageLongMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionSpotPercentageShortMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionDynamicPercentageShortMaintenance = _data.GetU64(offset);
                offset += 8;
                result.OptionShortPutCapPercentage = _data.GetU64(offset);
                offset += 8;
                result.ExpiryIntervalSeconds = _data.GetU32(offset);
                offset += 4;
                result.NewExpiryThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                result.MinFundingRatePercent = _data.GetS64(offset);
                offset += 8;
                result.MaxFundingRatePercent = _data.GetS64(offset);
                offset += 8;
                result.PerpImpactCashDelta = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class UpdateZetaGroupExpiryArgs
        {
            public uint ExpiryIntervalSeconds { get; set; }

            public uint NewExpiryThresholdSeconds { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU32(ExpiryIntervalSeconds, offset);
                offset += 4;
                _data.WriteU32(NewExpiryThresholdSeconds, offset);
                offset += 4;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out UpdateZetaGroupExpiryArgs result)
            {
                int offset = initialOffset;
                result = new UpdateZetaGroupExpiryArgs();
                result.ExpiryIntervalSeconds = _data.GetU32(offset);
                offset += 4;
                result.NewExpiryThresholdSeconds = _data.GetU32(offset);
                offset += 4;
                return offset - initialOffset;
            }
        }

        public partial class PositionMovementArg
        {
            public byte Index { get; set; }

            public long Size { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteU8(Index, offset);
                offset += 1;
                _data.WriteS64(Size, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PositionMovementArg result)
            {
                int offset = initialOffset;
                result = new PositionMovementArg();
                result.Index = _data.GetU8(offset);
                offset += 1;
                result.Size = _data.GetS64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public enum Kind : byte
        {
            Uninitialized,
            Call,
            Put,
            Future,
            Perp
        }

        public enum OrderType : byte
        {
            Limit,
            PostOnly,
            FillOrKill,
            ImmediateOrCancel
        }

        public enum Side : byte
        {
            Uninitialized,
            Bid,
            Ask
        }

        public enum Asset : byte
        {
            SOL,
            BTC,
            ETH,
            UNDEFINED
        }

        public enum MovementType : byte
        {
            Undefined,
            Lock,
            Unlock
        }

        public enum TreasuryMovementType : byte
        {
            Undefined,
            ToTreasuryFromInsurance,
            ToInsuranceFromTreasury,
            ToTreasuryFromReferralsRewards,
            ToReferralsRewardsFromTreasury
        }

        public enum MarginAccountType : byte
        {
            Normal,
            MarketMaker
        }
    }

    public partial class ZetaClient : TransactionalBaseClient<ZetaErrorKind>
    {
        public ZetaClient(IRpcClient rpcClient, IStreamingRpcClient streamingRpcClient, PublicKey programId) : base(rpcClient, streamingRpcClient, programId)
        {
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Greeks>>> GetGreekssAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = Greeks.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Greeks>>(res);
            List<Greeks> resultingAccounts = new List<Greeks>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Greeks.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Greeks>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarketIndexes>>> GetMarketIndexessAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = MarketIndexes.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarketIndexes>>(res);
            List<MarketIndexes> resultingAccounts = new List<MarketIndexes>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => MarketIndexes.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarketIndexes>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<OpenOrdersMap>>> GetOpenOrdersMapsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = OpenOrdersMap.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<OpenOrdersMap>>(res);
            List<OpenOrdersMap> resultingAccounts = new List<OpenOrdersMap>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => OpenOrdersMap.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<OpenOrdersMap>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<State>>> GetStatesAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = State.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<State>>(res);
            List<State> resultingAccounts = new List<State>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => State.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<State>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Underlying>>> GetUnderlyingsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = Underlying.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Underlying>>(res);
            List<Underlying> resultingAccounts = new List<Underlying>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Underlying.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Underlying>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SettlementAccount>>> GetSettlementAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = SettlementAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SettlementAccount>>(res);
            List<SettlementAccount> resultingAccounts = new List<SettlementAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => SettlementAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SettlementAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<PerpSyncQueue>>> GetPerpSyncQueuesAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = PerpSyncQueue.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<PerpSyncQueue>>(res);
            List<PerpSyncQueue> resultingAccounts = new List<PerpSyncQueue>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => PerpSyncQueue.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<PerpSyncQueue>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ZetaGroup>>> GetZetaGroupsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = ZetaGroup.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ZetaGroup>>(res);
            List<ZetaGroup> resultingAccounts = new List<ZetaGroup>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => ZetaGroup.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ZetaGroup>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarketNode>>> GetMarketNodesAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = MarketNode.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarketNode>>(res);
            List<MarketNode> resultingAccounts = new List<MarketNode>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => MarketNode.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarketNode>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SpreadAccount>>> GetSpreadAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = SpreadAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SpreadAccount>>(res);
            List<SpreadAccount> resultingAccounts = new List<SpreadAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => SpreadAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SpreadAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarginAccount>>> GetMarginAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = MarginAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarginAccount>>(res);
            List<MarginAccount> resultingAccounts = new List<MarginAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => MarginAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<MarginAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SocializedLossAccount>>> GetSocializedLossAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = SocializedLossAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SocializedLossAccount>>(res);
            List<SocializedLossAccount> resultingAccounts = new List<SocializedLossAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => SocializedLossAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<SocializedLossAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistDepositAccount>>> GetWhitelistDepositAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = WhitelistDepositAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistDepositAccount>>(res);
            List<WhitelistDepositAccount> resultingAccounts = new List<WhitelistDepositAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => WhitelistDepositAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistDepositAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistInsuranceAccount>>> GetWhitelistInsuranceAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = WhitelistInsuranceAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistInsuranceAccount>>(res);
            List<WhitelistInsuranceAccount> resultingAccounts = new List<WhitelistInsuranceAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => WhitelistInsuranceAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistInsuranceAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<InsuranceDepositAccount>>> GetInsuranceDepositAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = InsuranceDepositAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<InsuranceDepositAccount>>(res);
            List<InsuranceDepositAccount> resultingAccounts = new List<InsuranceDepositAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => InsuranceDepositAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<InsuranceDepositAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistTradingFeesAccount>>> GetWhitelistTradingFeesAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = WhitelistTradingFeesAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistTradingFeesAccount>>(res);
            List<WhitelistTradingFeesAccount> resultingAccounts = new List<WhitelistTradingFeesAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => WhitelistTradingFeesAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<WhitelistTradingFeesAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferrerAccount>>> GetReferrerAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = ReferrerAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferrerAccount>>(res);
            List<ReferrerAccount> resultingAccounts = new List<ReferrerAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => ReferrerAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferrerAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferralAccount>>> GetReferralAccountsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = ReferralAccount.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferralAccount>>(res);
            List<ReferralAccount> resultingAccounts = new List<ReferralAccount>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => ReferralAccount.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferralAccount>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferrerAlias>>> GetReferrerAliassAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = ReferrerAlias.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferrerAlias>>(res);
            List<ReferrerAlias> resultingAccounts = new List<ReferrerAlias>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => ReferrerAlias.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ReferrerAlias>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<Greeks>> GetGreeksAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<Greeks>(res);
            var resultingAccount = Greeks.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<Greeks>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<MarketIndexes>> GetMarketIndexesAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<MarketIndexes>(res);
            var resultingAccount = MarketIndexes.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<MarketIndexes>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<OpenOrdersMap>> GetOpenOrdersMapAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<OpenOrdersMap>(res);
            var resultingAccount = OpenOrdersMap.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<OpenOrdersMap>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<State>> GetStateAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<State>(res);
            var resultingAccount = State.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<State>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<Underlying>> GetUnderlyingAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<Underlying>(res);
            var resultingAccount = Underlying.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<Underlying>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<SettlementAccount>> GetSettlementAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<SettlementAccount>(res);
            var resultingAccount = SettlementAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<SettlementAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<PerpSyncQueue>> GetPerpSyncQueueAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<PerpSyncQueue>(res);
            var resultingAccount = PerpSyncQueue.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<PerpSyncQueue>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<ZetaGroup>> GetZetaGroupAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<ZetaGroup>(res);
            var resultingAccount = ZetaGroup.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<ZetaGroup>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<MarketNode>> GetMarketNodeAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<MarketNode>(res);
            var resultingAccount = MarketNode.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<MarketNode>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<SpreadAccount>> GetSpreadAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<SpreadAccount>(res);
            var resultingAccount = SpreadAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<SpreadAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<MarginAccount>> GetMarginAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<MarginAccount>(res);
            var resultingAccount = MarginAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<MarginAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<SocializedLossAccount>> GetSocializedLossAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<SocializedLossAccount>(res);
            var resultingAccount = SocializedLossAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<SocializedLossAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<WhitelistDepositAccount>> GetWhitelistDepositAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<WhitelistDepositAccount>(res);
            var resultingAccount = WhitelistDepositAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<WhitelistDepositAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<WhitelistInsuranceAccount>> GetWhitelistInsuranceAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<WhitelistInsuranceAccount>(res);
            var resultingAccount = WhitelistInsuranceAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<WhitelistInsuranceAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<InsuranceDepositAccount>> GetInsuranceDepositAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<InsuranceDepositAccount>(res);
            var resultingAccount = InsuranceDepositAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<InsuranceDepositAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<WhitelistTradingFeesAccount>> GetWhitelistTradingFeesAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<WhitelistTradingFeesAccount>(res);
            var resultingAccount = WhitelistTradingFeesAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<WhitelistTradingFeesAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<ReferrerAccount>> GetReferrerAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<ReferrerAccount>(res);
            var resultingAccount = ReferrerAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<ReferrerAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<ReferralAccount>> GetReferralAccountAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<ReferralAccount>(res);
            var resultingAccount = ReferralAccount.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<ReferralAccount>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<ReferrerAlias>> GetReferrerAliasAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<ReferrerAlias>(res);
            var resultingAccount = ReferrerAlias.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<ReferrerAlias>(res, resultingAccount);
        }

        public async Task<SubscriptionState> SubscribeGreeksAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Greeks> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Greeks parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Greeks.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeMarketIndexesAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, MarketIndexes> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                MarketIndexes parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = MarketIndexes.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeOpenOrdersMapAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, OpenOrdersMap> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                OpenOrdersMap parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = OpenOrdersMap.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeStateAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, State> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                State parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = State.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeUnderlyingAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Underlying> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Underlying parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Underlying.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeSettlementAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, SettlementAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                SettlementAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = SettlementAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribePerpSyncQueueAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, PerpSyncQueue> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                PerpSyncQueue parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = PerpSyncQueue.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeZetaGroupAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, ZetaGroup> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                ZetaGroup parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = ZetaGroup.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeMarketNodeAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, MarketNode> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                MarketNode parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = MarketNode.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeSpreadAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, SpreadAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                SpreadAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = SpreadAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeMarginAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, MarginAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                MarginAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = MarginAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeSocializedLossAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, SocializedLossAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                SocializedLossAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = SocializedLossAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeWhitelistDepositAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, WhitelistDepositAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                WhitelistDepositAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = WhitelistDepositAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeWhitelistInsuranceAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, WhitelistInsuranceAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                WhitelistInsuranceAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = WhitelistInsuranceAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeInsuranceDepositAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, InsuranceDepositAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                InsuranceDepositAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = InsuranceDepositAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeWhitelistTradingFeesAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, WhitelistTradingFeesAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                WhitelistTradingFeesAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = WhitelistTradingFeesAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeReferrerAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, ReferrerAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                ReferrerAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = ReferrerAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeReferralAccountAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, ReferralAccount> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                ReferralAccount parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = ReferralAccount.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeReferrerAliasAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, ReferrerAlias> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                ReferrerAlias parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = ReferrerAlias.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<RequestResult<string>> SendInitializeZetaGroupAsync(InitializeZetaGroupAccounts accounts, InitializeZetaGroupArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeZetaGroup(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendOverrideExpiryAsync(OverrideExpiryAccounts accounts, OverrideExpiryArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.OverrideExpiry(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeMarginAccountAsync(InitializeMarginAccountAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeMarginAccount(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeSpreadAccountAsync(InitializeSpreadAccountAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeSpreadAccount(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCloseMarginAccountAsync(CloseMarginAccountAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CloseMarginAccount(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCloseSpreadAccountAsync(CloseSpreadAccountAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CloseSpreadAccount(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializePerpSyncQueueAsync(InitializePerpSyncQueueAccounts accounts, byte nonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializePerpSyncQueue(accounts, nonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeMarketIndexesAsync(InitializeMarketIndexesAccounts accounts, byte nonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeMarketIndexes(accounts, nonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeMarketNodeAsync(InitializeMarketNodeAccounts accounts, InitializeMarketNodeArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeMarketNode(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendHaltZetaGroupAsync(HaltZetaGroupAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.HaltZetaGroup(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUnhaltZetaGroupAsync(UnhaltZetaGroupAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UnhaltZetaGroup(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateHaltStateAsync(UpdateHaltStateAccounts accounts, HaltZetaGroupArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateHaltState(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateVolatilityAsync(UpdateVolatilityAccounts accounts, UpdateVolatilityArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateVolatility(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateInterestRateAsync(UpdateInterestRateAccounts accounts, UpdateInterestRateArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateInterestRate(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendAddMarketIndexesAsync(AddMarketIndexesAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.AddMarketIndexes(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeZetaStateAsync(InitializeZetaStateAccounts accounts, InitializeStateArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeZetaState(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeZetaTreasuryWalletAsync(InitializeZetaTreasuryWalletAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeZetaTreasuryWallet(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeZetaReferralsRewardsWalletAsync(InitializeZetaReferralsRewardsWalletAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeZetaReferralsRewardsWallet(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateAdminAsync(UpdateAdminAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateAdmin(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateReferralsAdminAsync(UpdateReferralsAdminAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateReferralsAdmin(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateZetaStateAsync(UpdateZetaStateAccounts accounts, UpdateStateArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateZetaState(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateOracleAsync(UpdateOracleAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateOracle(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdatePricingParametersAsync(UpdatePricingParametersAccounts accounts, UpdatePricingParametersArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdatePricingParameters(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateMarginParametersAsync(UpdateMarginParametersAccounts accounts, UpdateMarginParametersArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateMarginParameters(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdatePerpParametersAsync(UpdatePerpParametersAccounts accounts, UpdatePerpParametersArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdatePerpParameters(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateZetaGroupExpiryParametersAsync(UpdateZetaGroupExpiryParametersAccounts accounts, UpdateZetaGroupExpiryArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateZetaGroupExpiryParameters(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCleanZetaMarketsAsync(CleanZetaMarketsAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CleanZetaMarkets(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCleanZetaMarketsHaltedAsync(CleanZetaMarketsHaltedAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CleanZetaMarketsHalted(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSettlePositionsAsync(SettlePositionsAccounts accounts, ulong expiryTs, byte settlementNonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.SettlePositions(accounts, expiryTs, settlementNonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSettlePositionsHaltedAsync(SettlePositionsHaltedAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.SettlePositionsHalted(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSettleSpreadPositionsAsync(SettleSpreadPositionsAccounts accounts, ulong expiryTs, byte settlementNonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.SettleSpreadPositions(accounts, expiryTs, settlementNonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSettleSpreadPositionsHaltedAsync(SettleSpreadPositionsHaltedAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.SettleSpreadPositionsHalted(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeMarketStrikesAsync(InitializeMarketStrikesAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeMarketStrikes(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendExpireSeriesOverrideAsync(ExpireSeriesOverrideAccounts accounts, ExpireSeriesOverrideArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ExpireSeriesOverride(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendExpireSeriesAsync(ExpireSeriesAccounts accounts, byte settlementNonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ExpireSeries(accounts, settlementNonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeZetaMarketAsync(InitializeZetaMarketAccounts accounts, InitializeMarketArgs args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeZetaMarket(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendRetreatMarketNodesAsync(RetreatMarketNodesAccounts accounts, byte expiryIndex, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.RetreatMarketNodes(accounts, expiryIndex, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCleanMarketNodesAsync(CleanMarketNodesAccounts accounts, byte expiryIndex, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CleanMarketNodes(accounts, expiryIndex, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateVolatilityNodesAsync(UpdateVolatilityNodesAccounts accounts, ulong[] nodes, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdateVolatilityNodes(accounts, nodes, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdatePricingAsync(UpdatePricingAccounts accounts, byte expiryIndex, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdatePricing(accounts, expiryIndex, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendApplyPerpFundingAsync(ApplyPerpFundingAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ApplyPerpFunding(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdatePricingHaltedAsync(UpdatePricingHaltedAccounts accounts, byte expiryIndex, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.UpdatePricingHalted(accounts, expiryIndex, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendDepositAsync(DepositAccounts accounts, ulong amount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.Deposit(accounts, amount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendDepositInsuranceVaultAsync(DepositInsuranceVaultAccounts accounts, ulong amount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.DepositInsuranceVault(accounts, amount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendWithdrawAsync(WithdrawAccounts accounts, ulong amount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.Withdraw(accounts, amount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendWithdrawInsuranceVaultAsync(WithdrawInsuranceVaultAccounts accounts, ulong percentageAmount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.WithdrawInsuranceVault(accounts, percentageAmount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeOpenOrdersAsync(InitializeOpenOrdersAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeOpenOrders(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCloseOpenOrdersAsync(CloseOpenOrdersAccounts accounts, byte mapNonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CloseOpenOrders(accounts, mapNonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeWhitelistDepositAccountAsync(InitializeWhitelistDepositAccountAccounts accounts, byte nonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeWhitelistDepositAccount(accounts, nonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeWhitelistInsuranceAccountAsync(InitializeWhitelistInsuranceAccountAccounts accounts, byte nonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeWhitelistInsuranceAccount(accounts, nonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeWhitelistTradingFeesAccountAsync(InitializeWhitelistTradingFeesAccountAccounts accounts, byte nonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeWhitelistTradingFeesAccount(accounts, nonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeInsuranceDepositAccountAsync(InitializeInsuranceDepositAccountAccounts accounts, byte nonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeInsuranceDepositAccount(accounts, nonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendPlaceOrderAsync(PlaceOrderAccounts accounts, ulong price, ulong size, Side side, ulong? clientOrderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.PlaceOrder(accounts, price, size, side, clientOrderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendPlaceOrderV2Async(PlaceOrderV2Accounts accounts, ulong price, ulong size, Side side, OrderType orderType, ulong? clientOrderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.PlaceOrderV2(accounts, price, size, side, orderType, clientOrderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendPlaceOrderV3Async(PlaceOrderV3Accounts accounts, ulong price, ulong size, Side side, OrderType orderType, ulong? clientOrderId, string tag, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.PlaceOrderV3(accounts, price, size, side, orderType, clientOrderId, tag, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendPlacePerpOrderAsync(PlacePerpOrderAccounts accounts, ulong price, ulong size, Side side, OrderType orderType, ulong? clientOrderId, string tag, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.PlacePerpOrder(accounts, price, size, side, orderType, clientOrderId, tag, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCancelOrderAsync(CancelOrderAccounts accounts, Side side, BigInteger orderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CancelOrder(accounts, side, orderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCancelOrderNoErrorAsync(CancelOrderNoErrorAccounts accounts, Side side, BigInteger orderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CancelOrderNoError(accounts, side, orderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCancelAllMarketOrdersAsync(CancelAllMarketOrdersAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CancelAllMarketOrders(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCancelOrderHaltedAsync(CancelOrderHaltedAccounts accounts, Side side, BigInteger orderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CancelOrderHalted(accounts, side, orderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCancelOrderByClientOrderIdAsync(CancelOrderByClientOrderIdAccounts accounts, ulong clientOrderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CancelOrderByClientOrderId(accounts, clientOrderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCancelOrderByClientOrderIdNoErrorAsync(CancelOrderByClientOrderIdNoErrorAccounts accounts, ulong clientOrderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CancelOrderByClientOrderIdNoError(accounts, clientOrderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCancelExpiredOrderAsync(CancelExpiredOrderAccounts accounts, Side side, BigInteger orderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CancelExpiredOrder(accounts, side, orderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendForceCancelOrderByOrderIdAsync(ForceCancelOrderByOrderIdAccounts accounts, Side side, BigInteger orderId, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ForceCancelOrderByOrderId(accounts, side, orderId, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendForceCancelOrdersAsync(ForceCancelOrdersAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ForceCancelOrders(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCrankEventQueueAsync(CrankEventQueueAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CrankEventQueue(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCollectTreasuryFundsAsync(CollectTreasuryFundsAccounts accounts, ulong amount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.CollectTreasuryFunds(accounts, amount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendTreasuryMovementAsync(TreasuryMovementAccounts accounts, TreasuryMovementType treasuryMovementType, ulong amount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.TreasuryMovement(accounts, treasuryMovementType, amount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendRebalanceInsuranceVaultAsync(RebalanceInsuranceVaultAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.RebalanceInsuranceVault(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendLiquidateAsync(LiquidateAccounts accounts, ulong size, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.Liquidate(accounts, size, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendBurnVaultTokensAsync(BurnVaultTokensAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.BurnVaultTokens(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSettleDexFundsAsync(SettleDexFundsAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.SettleDexFunds(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendPositionMovementAsync(PositionMovementAccounts accounts, MovementType movementType, PositionMovementArg[] movements, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.PositionMovement(accounts, movementType, movements, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendTransferExcessSpreadBalanceAsync(TransferExcessSpreadBalanceAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.TransferExcessSpreadBalance(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendToggleMarketMakerAsync(ToggleMarketMakerAccounts accounts, bool isMarketMaker, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ToggleMarketMaker(accounts, isMarketMaker, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeReferrerAccountAsync(InitializeReferrerAccountAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeReferrerAccount(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendReferUserAsync(ReferUserAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ReferUser(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitializeReferrerAliasAsync(InitializeReferrerAliasAccounts accounts, string alias, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.InitializeReferrerAlias(accounts, alias, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSetReferralsRewardsAsync(SetReferralsRewardsAccounts accounts, SetReferralsRewardsArgs[] args, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.SetReferralsRewards(accounts, args, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendClaimReferralsRewardsAsync(ClaimReferralsRewardsAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ZetaProgram.ClaimReferralsRewards(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        protected override Dictionary<uint, ProgramError<ZetaErrorKind>> BuildErrorsDictionary()
        {
            return new Dictionary<uint, ProgramError<ZetaErrorKind>>{{6000U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.DepositOverflow, "Deposit overflow")}, {6001U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.Unreachable, "Unreachable")}, {6002U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.FailedInitialMarginRequirement, "Failed initial margin requirement")}, {6003U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.LiquidatorFailedMarginRequirement, "Liquidator failed margin requirement")}, {6004U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotLiquidateOwnAccount, "Cannot liquidate own account")}, {6005U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CrankInvalidRemainingAccounts, "Invalid cranking remaining accounts")}, {6006U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.IncorrectTickSize, "Incorrect tick size")}, {6007U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ZeroPrice, "ZeroPrice")}, {6008U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ZeroSize, "ZeroSize")}, {6009U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ZeroWithdrawableBalance, "Zero withdrawable balance")}, {6010U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.DepositAmountExceeded, "Deposit amount exceeds limit and user is not whitelisted")}, {6011U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.WithdrawalAmountExceedsWithdrawableBalance, "Withdrawal amount exceeds withdrawable balance")}, {6012U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.AccountHasSufficientMarginPostCancels, "Account has sufficient margin post cancels")}, {6013U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.OverBankrupt, "Over bankrupt")}, {6014U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.AccountHasSufficientMargin, "Account has sufficient margin")}, {6015U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UserHasNoActiveOrders, "User has no active orders")}, {6016U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidExpirationInterval, "Invalid expiration interval")}, {6017U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ProductMarketsAlreadyInitialized, "Product markets already initialized")}, {6018U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidProductMarketKey, "Invalid product market key")}, {6019U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.MarketNotLive, "Market not live")}, {6020U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.MarketPricingNotReady, "Market pricing not ready")}, {6021U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UserHasRemainingOrdersOnExpiredMarket, "User has remaining orders on expired market")}, {6022U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidSeriesExpiration, "Invalid series expiration")}, {6023U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidExpiredOrderCancel, "Invalid expired order cancel")}, {6024U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.NoMarketsToAdd, "No markets to add")}, {6025U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UserHasUnsettledPositions, "User has unsettled positions")}, {6026U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.NoMarginAccountsToSettle, "No margin accounts to settle")}, {6027U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotSettleUserWithActiveOrders, "Cannot settle users with active orders")}, {6028U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.OrderbookNotEmpty, "Orderbook not empty")}, {6029U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidNumberOfAccounts, "Invalid number of accounts")}, {6030U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidMarketAccounts, "Bids or Asks don't match the Market")}, {6031U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ProductStrikeUninitialized, "Product strike uninitialized")}, {6032U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.PricingNotUpToDate, "Pricing not up to date")}, {6033U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.RetreatsAreStale, "Retreats are stale")}, {6034U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ProductDirty, "Product dirty")}, {6035U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ProductStrikesInitialized, "Product strikes initialized")}, {6036U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.StrikeInitializationNotReady, "Strike initialization not ready")}, {6037U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UnsupportedKind, "Unsupported kind")}, {6038U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidZetaGroup, "Invalid zeta group")}, {6039U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidMarginAccount, "Invalid margin account")}, {6040U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidGreeksAccount, "Invalid greeks account")}, {6041U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidSettlementAccount, "Invalid settlement account")}, {6042U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidCancelAuthority, "Invalid cancel authority")}, {6043U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotUpdatePricingAfterExpiry, "Cannot update pricing after expiry")}, {6044U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.LoadAccountDiscriminatorAlreadySet, "Account discriminator already set")}, {6045U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.AccountAlreadyInitialized, "Account already initialized")}, {6046U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.GreeksAccountSeedsMismatch, "Greeks account seeds mismatch")}, {6047U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ZetaGroupAccountSeedsMismatch, "Zeta group account seeds mismatch")}, {6048U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.MarginAccountSeedsMismatch, "Margin account seeds mismatch")}, {6049U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.OpenOrdersAccountSeedsMismatch, "Open orders account seeds mismatch")}, {6050U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.MarketNodeAccountSeedsMismatch, "Market node seeds mismatch")}, {6051U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UserTradingFeeWhitelistAccountSeedsMismatch, "User trading fee whitelist account seeds mismatch")}, {6052U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UserDepositWhitelistAccountSeedsMismatch, "User deposit whitelist account seeds mismatch")}, {6053U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.MarketIndexesUninitialized, "Market indexes uninitialized")}, {6054U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.MarketIndexesAlreadyInitialized, "Market indexes already initialized")}, {6055U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotGetUnsetStrike, "Cannot get unset strike")}, {6056U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotSetInitializedStrike, "Cannot set initialized strike")}, {6057U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotResetUninitializedStrike, "Cannot set initialized strike")}, {6058U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CrankMarginAccountNotMutable, "CrankMarginAccountNotMutable")}, {6059U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidAdminSigner, "InvalidAdminSigner")}, {6060U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UserHasActiveOrders, "User still has active orders")}, {6061U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UserForceCancelInProgress, "User has a force cancel in progress")}, {6062U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.FailedPriceBandCheck, "Failed price band check")}, {6063U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.UnsortedOpenOrdersAccounts, "Unsorted open orders accounts")}, {6064U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.AccountNotMutable, "Account not mutable")}, {6065U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.AccountDiscriminatorMismatch, "Account discriminator mismatch")}, {6066U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidMarketNodeIndex, "Invalid market node index")}, {6067U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidMarketNode, "Invalid market node")}, {6068U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.LUTOutOfBounds, "Lut out of bounds")}, {6069U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.RebalanceInsuranceInvalidRemainingAccounts, "Rebalance insurance vault with no margin accounts")}, {6070U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidMintDecimals, "Invalid mint decimals")}, {6071U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidZetaGroupOracle, "Invalid oracle for this zeta group")}, {6072U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidZetaGroupDepositMint, "Invalid zeta group deposit mint")}, {6073U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidZetaGroupRebalanceMint, "Invalid zeta group rebalance insurance vault mint")}, {6074U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidDepositAmount, "Invalid deposit amount")}, {6075U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidTokenAccountOwner, "Invalid token account owner")}, {6076U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidWithdrawAmount, "Invalid withdraw amount")}, {6077U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidDepositRemainingAccounts, "Invalid number of remaining accounts in deposit")}, {6078U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidPlaceOrderRemainingAccounts, "Invalid number of remaining accounts in place order")}, {6079U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ClientOrderIdCannotBeZero, "ClientOrderIdCannotBeZero")}, {6080U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ZetaGroupHalted, "Zeta group halted")}, {6081U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ZetaGroupNotHalted, "Zeta group not halted")}, {6082U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.HaltMarkPriceNotSet, "Halt mark price not set")}, {6083U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.HaltMarketsNotCleaned, "Halt markets not cleaned")}, {6084U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.HaltMarketNodesNotCleaned, "Halt market nodes not cleaned")}, {6085U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotExpireOptionsAfterExpirationThreshold, "Cannot expire options after expiration threshold")}, {6086U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.PostOnlyInCross, "Post only order in cross")}, {6087U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.FillOrKillNotFullSize, "Fill or kill order was not filled for full size")}, {6088U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidOpenOrdersMapOwner, "Invalid open orders map owner")}, {6089U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.AccountDidNotSerialize, "Failed to serialize the account")}, {6090U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.OpenOrdersWithNonEmptyPositions, "Cannot close open orders account with non empty positions")}, {6091U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotCloseNonEmptyMarginAccount, "Cannot close margin account that is not empty")}, {6092U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidTagLength, "Invalid tag length")}, {6093U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.NakedShortCallIsNotAllowed, "Naked short call is not allowed")}, {6094U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidSpreadAccount, "Invalid spread account")}, {6095U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotCloseNonEmptySpreadAccount, "Cannot close non empty spread account")}, {6096U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.SpreadAccountSeedsMismatch, "Spread account seeds mismatch")}, {6097U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.SpreadAccountHasUnsettledPositions, "Spread account seeds mismatch")}, {6098U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.SpreadAccountInvalidExpirySeriesState, "Spread account invalid expiry series state")}, {6099U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InsufficientFundsToCollateralizeSpreadAccount, "Insufficient funds to collateralize spread account")}, {6100U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.FailedMaintenanceMarginRequirement, "Failed maintenance margin requirement")}, {6101U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidMovement, "Invalid movement")}, {6102U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.MovementOnExpiredSeries, "Movement on expired series")}, {6103U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidMovementSize, "Invalid movement size")}, {6104U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ExceededMaxPositionMovements, "Exceeded max position movements")}, {6105U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ExceededMaxSpreadAccountContracts, "Exceeded max spread account contracts")}, {6106U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.OraclePriceIsInvalid, "Fetched oracle price is invalid")}, {6107U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidUnderlyingMint, "Provided underlying mint address is invalid")}, {6108U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidReferrerAlias, "Invalid referrer alias - Invalid length")}, {6109U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ReferrerAlreadyHasAlias, "Referrer already has alias")}, {6110U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidTreasuryMovementAmount, "Invalid treasury movement amount")}, {6111U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidReferralsAdminSigner, "Invalid referrals admin signer")}, {6112U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidSetReferralsRewardsRemainingAccounts, "Invalid set referrals rewards remaining accounts")}, {6113U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.SetReferralsRewardsAccountNotMutable, "Referrals account not mutable")}, {6114U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidClaimReferralsRewardsAmount, "Invalid claim referrals rewards: not enough in refererals rewards wallet")}, {6115U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidClaimReferralsRewardsAccount, "Invalid claim referrals rewards: referrals account is not a referral or referrer account")}, {6116U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ReferralAccountSeedsMismatch, "Referral account seeds mismatch")}, {6117U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ReferrerAccountSeedsMismatch, "Referrer account seeds mismatch")}, {6118U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.ProtectedMmMarginAccount, "Market maker accounts are protected from liquidation")}, {6119U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotWithdrawWithOpenOrders, "Cannot withdraw with open orders")}, {6120U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.FundingRateNotUpToDate, "Perp funding rate not up to date")}, {6121U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.PerpSyncQueueFull, "Perp taker/maker sync queue is full")}, {6122U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.PerpSyncQueueAccountSeedsMismatch, "PerpSyncQueue account seeds mismatch")}, {6123U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.PerpSyncQueueEmpty, "Program tried to pop from an empty perpSyncQueue")}, {6124U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidNonPerpMarket, "Perp product index given in placeOrder, use placePerpOrder")}, {6125U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.InvalidPerpMarket, "Non-perp product index given in placePerpOrder, use placeOrder")}, {6126U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.CannotInitializePerpMarketNode, "Not allowed to initialize market node for a perp market")}, {6127U, new ProgramError<ZetaErrorKind>(ZetaErrorKind.DeprecatedInstruction, "Instruction is deprecated, please use the newer version")}, };
        }
    }

    namespace Program
    {
        public class InitializeZetaGroupAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey UnderlyingMint { get; set; }

            public PublicKey ZetaProgram { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey PerpSyncQueue { get; set; }

            public PublicKey Underlying { get; set; }

            public PublicKey Vault { get; set; }

            public PublicKey InsuranceVault { get; set; }

            public PublicKey SocializedLossAccount { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey UsdcMint { get; set; }

            public PublicKey Rent { get; set; }
        }

        public class OverrideExpiryAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class InitializeMarginAccountAccounts
        {
            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey Payer { get; set; }

            public PublicKey ZetaProgram { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class InitializeSpreadAccountAccounts
        {
            public PublicKey SpreadAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey Payer { get; set; }

            public PublicKey ZetaProgram { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class CloseMarginAccountAccounts
        {
            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class CloseSpreadAccountAccounts
        {
            public PublicKey SpreadAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class InitializePerpSyncQueueAccounts
        {
            public PublicKey Admin { get; set; }

            public PublicKey ZetaProgram { get; set; }

            public PublicKey State { get; set; }

            public PublicKey PerpSyncQueue { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey SystemProgram { get; set; }
        }

        public class InitializeMarketIndexesAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey MarketIndexes { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class InitializeMarketNodeAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarketNode { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Payer { get; set; }

            public PublicKey SystemProgram { get; set; }
        }

        public class HaltZetaGroupAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UnhaltZetaGroupAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey Greeks { get; set; }
        }

        public class UpdateHaltStateAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdateVolatilityAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdateInterestRateAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class AddMarketIndexesAccounts
        {
            public PublicKey MarketIndexes { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class InitializeZetaStateAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey MintAuthority { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey TreasuryWallet { get; set; }

            public PublicKey ReferralsAdmin { get; set; }

            public PublicKey ReferralsRewardsWallet { get; set; }

            public PublicKey Rent { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey UsdcMint { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class InitializeZetaTreasuryWalletAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey TreasuryWallet { get; set; }

            public PublicKey Rent { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey UsdcMint { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class InitializeZetaReferralsRewardsWalletAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ReferralsRewardsWallet { get; set; }

            public PublicKey Rent { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey UsdcMint { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdateAdminAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey NewAdmin { get; set; }
        }

        public class UpdateReferralsAdminAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey NewAdmin { get; set; }
        }

        public class UpdateZetaStateAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdateOracleAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey Oracle { get; set; }
        }

        public class UpdatePricingParametersAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdateMarginParametersAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdatePerpParametersAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdateZetaGroupExpiryParametersAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class CleanZetaMarketsAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class CleanZetaMarketsHaltedAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }
        }

        public class SettlePositionsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey SettlementAccount { get; set; }
        }

        public class SettlePositionsHaltedAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class SettleSpreadPositionsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey SettlementAccount { get; set; }
        }

        public class SettleSpreadPositionsHaltedAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class InitializeMarketStrikesAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Oracle { get; set; }
        }

        public class ExpireSeriesOverrideAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey SettlementAccount { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey Greeks { get; set; }
        }

        public class ExpireSeriesAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey SettlementAccount { get; set; }

            public PublicKey Payer { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey Greeks { get; set; }
        }

        public class InitializeZetaMarketAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey MarketIndexes { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey RequestQueue { get; set; }

            public PublicKey EventQueue { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey BaseMint { get; set; }

            public PublicKey QuoteMint { get; set; }

            public PublicKey ZetaBaseVault { get; set; }

            public PublicKey ZetaQuoteVault { get; set; }

            public PublicKey DexBaseVault { get; set; }

            public PublicKey DexQuoteVault { get; set; }

            public PublicKey VaultOwner { get; set; }

            public PublicKey MintAuthority { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey Rent { get; set; }
        }

        public class RetreatMarketNodesAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Oracle { get; set; }
        }

        public class CleanMarketNodesAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }
        }

        public class UpdateVolatilityNodesAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class UpdatePricingAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey PerpMarket { get; set; }

            public PublicKey PerpBids { get; set; }

            public PublicKey PerpAsks { get; set; }
        }

        public class ApplyPerpFundingAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }
        }

        public class UpdatePricingHaltedAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey PerpMarket { get; set; }

            public PublicKey PerpBids { get; set; }

            public PublicKey PerpAsks { get; set; }
        }

        public class DepositAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey Vault { get; set; }

            public PublicKey UserTokenAccount { get; set; }

            public PublicKey SocializedLossAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey State { get; set; }

            public PublicKey Greeks { get; set; }
        }

        public class DepositInsuranceVaultAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey InsuranceVault { get; set; }

            public PublicKey InsuranceDepositAccount { get; set; }

            public PublicKey UserTokenAccount { get; set; }

            public PublicKey ZetaVault { get; set; }

            public PublicKey SocializedLossAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey TokenProgram { get; set; }
        }

        public class WithdrawAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Vault { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey UserTokenAccount { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey SocializedLossAccount { get; set; }
        }

        public class WithdrawInsuranceVaultAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey InsuranceVault { get; set; }

            public PublicKey InsuranceDepositAccount { get; set; }

            public PublicKey UserTokenAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey TokenProgram { get; set; }
        }

        public class InitializeOpenOrdersAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey Payer { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrdersMap { get; set; }

            public PublicKey Rent { get; set; }
        }

        public class CloseOpenOrdersAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrdersMap { get; set; }
        }

        public class InitializeWhitelistDepositAccountAccounts
        {
            public PublicKey WhitelistDepositAccount { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey User { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey State { get; set; }
        }

        public class InitializeWhitelistInsuranceAccountAccounts
        {
            public PublicKey WhitelistInsuranceAccount { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey User { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey State { get; set; }
        }

        public class InitializeWhitelistTradingFeesAccountAccounts
        {
            public PublicKey WhitelistTradingFeesAccount { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey User { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey State { get; set; }
        }

        public class InitializeInsuranceDepositAccountAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey InsuranceDepositAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey SystemProgram { get; set; }

            public PublicKey WhitelistInsuranceAccount { get; set; }
        }

        public class PlaceOrderMarketAccountsAccounts
        {
            public PublicKey Market { get; set; }

            public PublicKey RequestQueue { get; set; }

            public PublicKey EventQueue { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey OrderPayerTokenAccount { get; set; }

            public PublicKey CoinVault { get; set; }

            public PublicKey PcVault { get; set; }

            public PublicKey CoinWallet { get; set; }

            public PublicKey PcWallet { get; set; }
        }

        public class PlaceOrderAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Rent { get; set; }

            public PlaceOrderMarketAccountsAccounts MarketAccounts { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey MarketNode { get; set; }

            public PublicKey MarketMint { get; set; }

            public PublicKey MintAuthority { get; set; }
        }

        public class PlaceOrderV2MarketAccountsAccounts
        {
            public PublicKey Market { get; set; }

            public PublicKey RequestQueue { get; set; }

            public PublicKey EventQueue { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey OrderPayerTokenAccount { get; set; }

            public PublicKey CoinVault { get; set; }

            public PublicKey PcVault { get; set; }

            public PublicKey CoinWallet { get; set; }

            public PublicKey PcWallet { get; set; }
        }

        public class PlaceOrderV2Accounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Rent { get; set; }

            public PlaceOrderV2MarketAccountsAccounts MarketAccounts { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey MarketNode { get; set; }

            public PublicKey MarketMint { get; set; }

            public PublicKey MintAuthority { get; set; }
        }

        public class PlaceOrderV3MarketAccountsAccounts
        {
            public PublicKey Market { get; set; }

            public PublicKey RequestQueue { get; set; }

            public PublicKey EventQueue { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey OrderPayerTokenAccount { get; set; }

            public PublicKey CoinVault { get; set; }

            public PublicKey PcVault { get; set; }

            public PublicKey CoinWallet { get; set; }

            public PublicKey PcWallet { get; set; }
        }

        public class PlaceOrderV3Accounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Rent { get; set; }

            public PlaceOrderV3MarketAccountsAccounts MarketAccounts { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey MarketNode { get; set; }

            public PublicKey MarketMint { get; set; }

            public PublicKey MintAuthority { get; set; }
        }

        public class PlacePerpOrderMarketAccountsAccounts
        {
            public PublicKey Market { get; set; }

            public PublicKey RequestQueue { get; set; }

            public PublicKey EventQueue { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey OrderPayerTokenAccount { get; set; }

            public PublicKey CoinVault { get; set; }

            public PublicKey PcVault { get; set; }

            public PublicKey CoinWallet { get; set; }

            public PublicKey PcWallet { get; set; }
        }

        public class PlacePerpOrderAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Rent { get; set; }

            public PlacePerpOrderMarketAccountsAccounts MarketAccounts { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey MarketMint { get; set; }

            public PublicKey MintAuthority { get; set; }

            public PublicKey PerpSyncQueue { get; set; }
        }

        public class CancelOrderCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class CancelOrderAccounts
        {
            public PublicKey Authority { get; set; }

            public CancelOrderCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class CancelOrderNoErrorCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class CancelOrderNoErrorAccounts
        {
            public PublicKey Authority { get; set; }

            public CancelOrderNoErrorCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class CancelAllMarketOrdersCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class CancelAllMarketOrdersAccounts
        {
            public PublicKey Authority { get; set; }

            public CancelAllMarketOrdersCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class CancelOrderHaltedCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class CancelOrderHaltedAccounts
        {
            public CancelOrderHaltedCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class CancelOrderByClientOrderIdCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class CancelOrderByClientOrderIdAccounts
        {
            public PublicKey Authority { get; set; }

            public CancelOrderByClientOrderIdCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class CancelOrderByClientOrderIdNoErrorCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class CancelOrderByClientOrderIdNoErrorAccounts
        {
            public PublicKey Authority { get; set; }

            public CancelOrderByClientOrderIdNoErrorCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class CancelExpiredOrderCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class CancelExpiredOrderAccounts
        {
            public CancelExpiredOrderCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class ForceCancelOrderByOrderIdCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class ForceCancelOrderByOrderIdAccounts
        {
            public PublicKey Greeks { get; set; }

            public PublicKey Oracle { get; set; }

            public ForceCancelOrderByOrderIdCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class ForceCancelOrdersCancelAccountsAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey State { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey OpenOrders { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey Bids { get; set; }

            public PublicKey Asks { get; set; }

            public PublicKey EventQueue { get; set; }
        }

        public class ForceCancelOrdersAccounts
        {
            public PublicKey Greeks { get; set; }

            public PublicKey Oracle { get; set; }

            public ForceCancelOrdersCancelAccountsAccounts CancelAccounts { get; set; }
        }

        public class CrankEventQueueAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey EventQueue { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey SerumAuthority { get; set; }
        }

        public class CollectTreasuryFundsAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey TreasuryWallet { get; set; }

            public PublicKey CollectionTokenAccount { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class TreasuryMovementAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey InsuranceVault { get; set; }

            public PublicKey TreasuryWallet { get; set; }

            public PublicKey ReferralsRewardsWallet { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey Admin { get; set; }
        }

        public class RebalanceInsuranceVaultAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey ZetaVault { get; set; }

            public PublicKey InsuranceVault { get; set; }

            public PublicKey TreasuryWallet { get; set; }

            public PublicKey SocializedLossAccount { get; set; }

            public PublicKey TokenProgram { get; set; }
        }

        public class LiquidateAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Liquidator { get; set; }

            public PublicKey LiquidatorMarginAccount { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Oracle { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey LiquidatedMarginAccount { get; set; }
        }

        public class BurnVaultTokensAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Mint { get; set; }

            public PublicKey Vault { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey TokenProgram { get; set; }
        }

        public class SettleDexFundsAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Market { get; set; }

            public PublicKey ZetaBaseVault { get; set; }

            public PublicKey ZetaQuoteVault { get; set; }

            public PublicKey DexBaseVault { get; set; }

            public PublicKey DexQuoteVault { get; set; }

            public PublicKey VaultOwner { get; set; }

            public PublicKey MintAuthority { get; set; }

            public PublicKey SerumAuthority { get; set; }

            public PublicKey DexProgram { get; set; }

            public PublicKey TokenProgram { get; set; }
        }

        public class PositionMovementAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey SpreadAccount { get; set; }

            public PublicKey Authority { get; set; }

            public PublicKey Greeks { get; set; }

            public PublicKey Oracle { get; set; }
        }

        public class TransferExcessSpreadBalanceAccounts
        {
            public PublicKey ZetaGroup { get; set; }

            public PublicKey MarginAccount { get; set; }

            public PublicKey SpreadAccount { get; set; }

            public PublicKey Authority { get; set; }
        }

        public class ToggleMarketMakerAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey Admin { get; set; }

            public PublicKey MarginAccount { get; set; }
        }

        public class InitializeReferrerAccountAccounts
        {
            public PublicKey Referrer { get; set; }

            public PublicKey ReferrerAccount { get; set; }

            public PublicKey SystemProgram { get; set; }
        }

        public class ReferUserAccounts
        {
            public PublicKey User { get; set; }

            public PublicKey ReferrerAccount { get; set; }

            public PublicKey ReferralAccount { get; set; }

            public PublicKey SystemProgram { get; set; }
        }

        public class InitializeReferrerAliasAccounts
        {
            public PublicKey Referrer { get; set; }

            public PublicKey ReferrerAlias { get; set; }

            public PublicKey ReferrerAccount { get; set; }

            public PublicKey SystemProgram { get; set; }
        }

        public class SetReferralsRewardsAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ReferralsAdmin { get; set; }
        }

        public class ClaimReferralsRewardsAccounts
        {
            public PublicKey State { get; set; }

            public PublicKey ReferralsRewardsWallet { get; set; }

            public PublicKey UserReferralsAccount { get; set; }

            public PublicKey UserTokenAccount { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey User { get; set; }
        }

        public static class ZetaProgram
        {
            public static Solnet.Rpc.Models.TransactionInstruction InitializeZetaGroup(InitializeZetaGroupAccounts accounts, InitializeZetaGroupArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.UnderlyingMint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.PerpSyncQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Underlying, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Vault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SocializedLossAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.UsdcMint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5186500956042594054UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction OverrideExpiry(OverrideExpiryAccounts accounts, OverrideExpiryArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9858229416997799297UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeMarginAccount(InitializeMarginAccountAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Payer, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(14229311758140631875UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeSpreadAccount(InitializeSpreadAccountAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.SpreadAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Payer, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(15210748703569303246UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CloseMarginAccount(CloseMarginAccountAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7422441976767305577UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CloseSpreadAccount(CloseSpreadAccountAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.SpreadAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(17339303631647532222UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializePerpSyncQueue(InitializePerpSyncQueueAccounts accounts, byte nonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.PerpSyncQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(621970096396056330UL, offset);
                offset += 8;
                _data.WriteU8(nonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeMarketIndexes(InitializeMarketIndexesAccounts accounts, byte nonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketIndexes, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8696823703222959963UL, offset);
                offset += 8;
                _data.WriteU8(nonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeMarketNode(InitializeMarketNodeAccounts accounts, InitializeMarketNodeArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketNode, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Payer, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9230119409355683378UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction HaltZetaGroup(HaltZetaGroupAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8471972133905515291UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UnhaltZetaGroup(UnhaltZetaGroupAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(18270829386722798628UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateHaltState(UpdateHaltStateAccounts accounts, HaltZetaGroupArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(4541188174549167575UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateVolatility(UpdateVolatilityAccounts accounts, UpdateVolatilityArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(6039545790869039550UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateInterestRate(UpdateInterestRateAccounts accounts, UpdateInterestRateArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(17187771903054383179UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction AddMarketIndexes(AddMarketIndexesAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketIndexes, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(18224277707163760222UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeZetaState(InitializeZetaStateAccounts accounts, InitializeStateArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MintAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.TreasuryWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ReferralsAdmin, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferralsRewardsWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.UsdcMint, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16023405875654502212UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeZetaTreasuryWallet(InitializeZetaTreasuryWalletAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.TreasuryWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.UsdcMint, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16655833938106464761UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeZetaReferralsRewardsWallet(InitializeZetaReferralsRewardsWalletAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferralsRewardsWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.UsdcMint, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(17939955007304492533UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateAdmin(UpdateAdminAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.NewAdmin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16479718032892539041UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateReferralsAdmin(UpdateReferralsAdminAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.NewAdmin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(14416139275275636809UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateZetaState(UpdateZetaStateAccounts accounts, UpdateStateArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(233241616646977128UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateOracle(UpdateOracleAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13618008928357001584UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdatePricingParameters(UpdatePricingParametersAccounts accounts, UpdatePricingParametersArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(17830099734200614761UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateMarginParameters(UpdateMarginParametersAccounts accounts, UpdateMarginParametersArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(17026074427150709317UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdatePerpParameters(UpdatePerpParametersAccounts accounts, UpdatePerpParametersArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12565472474992183130UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateZetaGroupExpiryParameters(UpdateZetaGroupExpiryParametersAccounts accounts, UpdateZetaGroupExpiryArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(15532016682409739537UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CleanZetaMarkets(CleanZetaMarketsAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(11337218619180416890UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CleanZetaMarketsHalted(CleanZetaMarketsHaltedAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(6815710213439546495UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction SettlePositions(SettlePositionsAccounts accounts, ulong expiryTs, byte settlementNonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SettlementAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(6281601033672606251UL, offset);
                offset += 8;
                _data.WriteU64(expiryTs, offset);
                offset += 8;
                _data.WriteU8(settlementNonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction SettlePositionsHalted(SettlePositionsHaltedAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5595555495588631466UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction SettleSpreadPositions(SettleSpreadPositionsAccounts accounts, ulong expiryTs, byte settlementNonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SettlementAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(4705453906750489427UL, offset);
                offset += 8;
                _data.WriteU64(expiryTs, offset);
                offset += 8;
                _data.WriteU8(settlementNonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction SettleSpreadPositionsHalted(SettleSpreadPositionsHaltedAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(2466297510144742814UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeMarketStrikes(InitializeMarketStrikesAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12334098781266980541UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ExpireSeriesOverride(ExpireSeriesOverrideAccounts accounts, ExpireSeriesOverrideArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SettlementAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5080869991664981608UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ExpireSeries(ExpireSeriesAccounts accounts, byte settlementNonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SettlementAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Payer, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9199469944208204333UL, offset);
                offset += 8;
                _data.WriteU8(settlementNonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeZetaMarket(InitializeZetaMarketAccounts accounts, InitializeMarketArgs args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MarketIndexes, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.RequestQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.EventQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.BaseMint, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.QuoteMint, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaBaseVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaQuoteVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.DexBaseVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.DexQuoteVault, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.VaultOwner, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MintAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(278558172445339508UL, offset);
                offset += 8;
                offset += args.Serialize(_data, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction RetreatMarketNodes(RetreatMarketNodesAccounts accounts, byte expiryIndex, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12904711067063057418UL, offset);
                offset += 8;
                _data.WriteU8(expiryIndex, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CleanMarketNodes(CleanMarketNodesAccounts accounts, byte expiryIndex, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16372790354443117369UL, offset);
                offset += 8;
                _data.WriteU8(expiryIndex, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdateVolatilityNodes(UpdateVolatilityNodesAccounts accounts, ulong[] nodes, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(17067486211322718820UL, offset);
                offset += 8;
                foreach (var nodesElement in nodes)
                {
                    _data.WriteU64(nodesElement, offset);
                    offset += 8;
                }

                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdatePricing(UpdatePricingAccounts accounts, byte expiryIndex, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.PerpMarket, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.PerpBids, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.PerpAsks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(1368418188384067997UL, offset);
                offset += 8;
                _data.WriteU8(expiryIndex, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ApplyPerpFunding(ApplyPerpFundingAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(18151330432919097879UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction UpdatePricingHalted(UpdatePricingHaltedAccounts accounts, byte expiryIndex, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.PerpMarket, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.PerpBids, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.PerpAsks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(1379806441718499075UL, offset);
                offset += 8;
                _data.WriteU8(expiryIndex, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction Deposit(DepositAccounts accounts, ulong amount, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Vault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SocializedLossAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13182846803881894898UL, offset);
                offset += 8;
                _data.WriteU64(amount, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction DepositInsuranceVault(DepositInsuranceVaultAccounts accounts, ulong amount, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceDepositAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SocializedLossAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(1591594127682254127UL, offset);
                offset += 8;
                _data.WriteU64(amount, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction Withdraw(WithdrawAccounts accounts, ulong amount, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Vault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserTokenAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SocializedLossAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(2495396153584390839UL, offset);
                offset += 8;
                _data.WriteU64(amount, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction WithdrawInsuranceVault(WithdrawInsuranceVaultAccounts accounts, ulong percentageAmount, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceDepositAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserTokenAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16235887514011171345UL, offset);
                offset += 8;
                _data.WriteU64(percentageAmount, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeOpenOrders(InitializeOpenOrdersAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Payer, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Market, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrdersMap, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13870570512709642807UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CloseOpenOrders(CloseOpenOrdersAccounts accounts, byte mapNonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Market, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrdersMap, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(1513180921572874440UL, offset);
                offset += 8;
                _data.WriteU8(mapNonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeWhitelistDepositAccount(InitializeWhitelistDepositAccountAccounts accounts, byte nonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.WhitelistDepositAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.User, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9988688556454045501UL, offset);
                offset += 8;
                _data.WriteU8(nonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeWhitelistInsuranceAccount(InitializeWhitelistInsuranceAccountAccounts accounts, byte nonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.WhitelistInsuranceAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.User, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7374086184125869611UL, offset);
                offset += 8;
                _data.WriteU8(nonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeWhitelistTradingFeesAccount(InitializeWhitelistTradingFeesAccountAccounts accounts, byte nonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.WhitelistTradingFeesAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.User, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13720530689573028294UL, offset);
                offset += 8;
                _data.WriteU8(nonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeInsuranceDepositAccount(InitializeInsuranceDepositAccountAccounts accounts, byte nonce, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceDepositAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.WhitelistInsuranceAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(2677855670928319317UL, offset);
                offset += 8;
                _data.WriteU8(nonce, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction PlaceOrder(PlaceOrderAccounts accounts, ulong price, ulong size, Side side, ulong? clientOrderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.RequestQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.EventQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.OrderPayerTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketNode, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketMint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MintAuthority, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7665269973393850931UL, offset);
                offset += 8;
                _data.WriteU64(price, offset);
                offset += 8;
                _data.WriteU64(size, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                if (clientOrderId != null)
                {
                    _data.WriteU8(1, offset);
                    offset += 1;
                    _data.WriteU64(clientOrderId.Value, offset);
                    offset += 8;
                }
                else
                {
                    _data.WriteU8(0, offset);
                    offset += 1;
                }

                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction PlaceOrderV2(PlaceOrderV2Accounts accounts, ulong price, ulong size, Side side, OrderType orderType, ulong? clientOrderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.RequestQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.EventQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.OrderPayerTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketNode, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketMint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MintAuthority, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(14717358883659280360UL, offset);
                offset += 8;
                _data.WriteU64(price, offset);
                offset += 8;
                _data.WriteU64(size, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteU8((byte)orderType, offset);
                offset += 1;
                if (clientOrderId != null)
                {
                    _data.WriteU8(1, offset);
                    offset += 1;
                    _data.WriteU64(clientOrderId.Value, offset);
                    offset += 8;
                }
                else
                {
                    _data.WriteU8(0, offset);
                    offset += 1;
                }

                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction PlaceOrderV3(PlaceOrderV3Accounts accounts, ulong price, ulong size, Side side, OrderType orderType, ulong? clientOrderId, string tag, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.RequestQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.EventQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.OrderPayerTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketNode, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketMint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MintAuthority, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(4181051979995176338UL, offset);
                offset += 8;
                _data.WriteU64(price, offset);
                offset += 8;
                _data.WriteU64(size, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteU8((byte)orderType, offset);
                offset += 1;
                if (clientOrderId != null)
                {
                    _data.WriteU8(1, offset);
                    offset += 1;
                    _data.WriteU64(clientOrderId.Value, offset);
                    offset += 8;
                }
                else
                {
                    _data.WriteU8(0, offset);
                    offset += 1;
                }

                if (tag != null)
                {
                    _data.WriteU8(1, offset);
                    offset += 1;
                    offset += _data.WriteBorshString(tag, offset);
                }
                else
                {
                    _data.WriteU8(0, offset);
                    offset += 1;
                }

                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction PlacePerpOrder(PlacePerpOrderAccounts accounts, ulong price, ulong size, Side side, OrderType orderType, ulong? clientOrderId, string tag, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Rent, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.RequestQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.EventQueue, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.OrderPayerTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.CoinWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketAccounts.PcWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarketMint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MintAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.PerpSyncQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13352186052502987077UL, offset);
                offset += 8;
                _data.WriteU64(price, offset);
                offset += 8;
                _data.WriteU64(size, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteU8((byte)orderType, offset);
                offset += 1;
                if (clientOrderId != null)
                {
                    _data.WriteU8(1, offset);
                    offset += 1;
                    _data.WriteU64(clientOrderId.Value, offset);
                    offset += 8;
                }
                else
                {
                    _data.WriteU8(0, offset);
                    offset += 1;
                }

                if (tag != null)
                {
                    _data.WriteU8(1, offset);
                    offset += 1;
                    offset += _data.WriteBorshString(tag, offset);
                }
                else
                {
                    _data.WriteU8(0, offset);
                    offset += 1;
                }

                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CancelOrder(CancelOrderAccounts accounts, Side side, BigInteger orderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9574425247284560223UL, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteBigInt(orderId, offset, 16, true);
                offset += 16;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CancelOrderNoError(CancelOrderNoErrorAccounts accounts, Side side, BigInteger orderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13316074753498767711UL, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteBigInt(orderId, offset, 16, true);
                offset += 16;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CancelAllMarketOrders(CancelAllMarketOrdersAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(346390478119681675UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CancelOrderHalted(CancelOrderHaltedAccounts accounts, Side side, BigInteger orderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12214602199181410304UL, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteBigInt(orderId, offset, 16, true);
                offset += 16;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CancelOrderByClientOrderId(CancelOrderByClientOrderIdAccounts accounts, ulong clientOrderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8609677075043431027UL, offset);
                offset += 8;
                _data.WriteU64(clientOrderId, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CancelOrderByClientOrderIdNoError(CancelOrderByClientOrderIdNoErrorAccounts accounts, ulong clientOrderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12362525767419514165UL, offset);
                offset += 8;
                _data.WriteU64(clientOrderId, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CancelExpiredOrder(CancelExpiredOrderAccounts accounts, Side side, BigInteger orderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(7198181139809335512UL, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteBigInt(orderId, offset, 16, true);
                offset += 16;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ForceCancelOrderByOrderId(ForceCancelOrderByOrderIdAccounts accounts, Side side, BigInteger orderId, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(17353079617416653750UL, offset);
                offset += 8;
                _data.WriteU8((byte)side, offset);
                offset += 1;
                _data.WriteBigInt(orderId, offset, 16, true);
                offset += 16;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ForceCancelOrders(ForceCancelOrdersAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.CancelAccounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.OpenOrders, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Bids, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.Asks, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CancelAccounts.EventQueue, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16735456334698558784UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CrankEventQueue(CrankEventQueueAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.EventQueue, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(13108778616829871427UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction CollectTreasuryFunds(CollectTreasuryFundsAccounts accounts, ulong amount, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.TreasuryWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.CollectionTokenAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(12588957453896701427UL, offset);
                offset += 8;
                _data.WriteU64(amount, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction TreasuryMovement(TreasuryMovementAccounts accounts, TreasuryMovementType treasuryMovementType, ulong amount, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.TreasuryWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferralsRewardsWallet, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(1341461186175181313UL, offset);
                offset += 8;
                _data.WriteU8((byte)treasuryMovementType, offset);
                offset += 1;
                _data.WriteU64(amount, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction RebalanceInsuranceVault(RebalanceInsuranceVaultAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.InsuranceVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.TreasuryWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SocializedLossAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8061422699622351883UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction Liquidate(LiquidateAccounts accounts, ulong size, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Liquidator, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.LiquidatorMarginAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Market, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.LiquidatedMarginAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5343290268703699935UL, offset);
                offset += 8;
                _data.WriteU64(size, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction BurnVaultTokens(BurnVaultTokensAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Mint, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Vault, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(11510122781654502377UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction SettleDexFunds(SettleDexFundsAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Market, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaBaseVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ZetaQuoteVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.DexBaseVault, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.DexQuoteVault, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.VaultOwner, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.MintAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SerumAuthority, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.DexProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(16289140328060839845UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction PositionMovement(PositionMovementAccounts accounts, MovementType movementType, PositionMovementArg[] movements, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SpreadAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Greeks, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Oracle, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(10640738955551248501UL, offset);
                offset += 8;
                _data.WriteU8((byte)movementType, offset);
                offset += 1;
                _data.WriteS32(movements.Length, offset);
                offset += 4;
                foreach (var movementsElement in movements)
                {
                    offset += movementsElement.Serialize(_data, offset);
                }

                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction TransferExcessSpreadBalance(TransferExcessSpreadBalanceAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ZetaGroup, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.SpreadAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Authority, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(15366397600815954092UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ToggleMarketMaker(ToggleMarketMakerAccounts accounts, bool isMarketMaker, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Admin, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.MarginAccount, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(5806544445378983883UL, offset);
                offset += 8;
                _data.WriteBool(isMarketMaker, offset);
                offset += 1;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeReferrerAccount(InitializeReferrerAccountAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.Referrer, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferrerAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(302659573339806765UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ReferUser(ReferUserAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.User, true), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ReferrerAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferralAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9847720617084351033UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction InitializeReferrerAlias(InitializeReferrerAliasAccounts accounts, string alias, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.Writable(accounts.Referrer, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferrerAlias, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferrerAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(9949696826628316227UL, offset);
                offset += 8;
                offset += _data.WriteBorshString(alias, offset);
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction SetReferralsRewards(SetReferralsRewardsAccounts accounts, SetReferralsRewardsArgs[] args, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.ReferralsAdmin, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(11406781450205390910UL, offset);
                offset += 8;
                _data.WriteS32(args.Length, offset);
                offset += 4;
                foreach (var argsElement in args)
                {
                    offset += argsElement.Serialize(_data, offset);
                }

                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction ClaimReferralsRewards(ClaimReferralsRewardsAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.State, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ReferralsRewardsWallet, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserReferralsAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserTokenAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.User, true)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(10365557491695983737UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }
        }
    }
}