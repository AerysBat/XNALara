using Microsoft.Xna.Framework.Graphics;

namespace XNALara
{
    public enum ItemType
    {
        None,

        Lara_Jungle_Shorts,
        Lara_Jungle_Pants,
        Lara_Jungle_Heavy,
        Lara_WetSuit,
        Lara_WetSuit_NoGear,
        Lara_DrySuit,
        Lara_Bathing_Suit,
        Lara_Bathing_Suit_NoGear,
        Lara_Casual,
        Lara_Snow_Light,
        Lara_Snow_Heavy,

        Lara_DLC_Bikini_BlackWhite,
        Lara_DLC_Bikini_Blue,
        Lara_DLC_Bikini_Camo,
        Lara_DLC_Bikini_Yellow,
        Lara_DLC_Casual_Explorer,
        Lara_DLC_Classic,
        Lara_DLC_Designer_Fashion_Winner,
        Lara_DLC_Designer_Peoples_Choice,
        Lara_DLC_DrySuit_Red,
        Lara_DLC_Jungle_Shorts_Grey,
        Lara_DLC_Legend,
        Lara_DLC_WetSuit_Blue,
        
        Natla,
        Natla_NoWings,
        Doppelganger,
        Amanda_Light,
        Amanda_Heavy,
        Amelia,
        Alister,
        Zip,
        Winston,

        Braid,
        Ponytail,
        Hair_Amanda,
        Hair_Natla,
        Hair_Alister,
        Wings,
        
        Tiger1,
        Tiger2,
        Panther,
        Shark_Blue,
        Shark_Greenland,
        Kraken,
        Jellyfish,
        Naga_Green,
        Naga_Red,
        Albino_Spider,
        
        Diver_Captain,
        Mercenary,
        Poacher,

        Knight_Thrall,
        Mayan_Thrall,
        Viking_Thrall,
        Yeti_Thrall,
        Yeti_Thrall_NoChains,
        Panther_Thrall,

        Glasses,
        Recorder,
        Grapple,
        Motorcycle,
        Helicopter,
        Mjolnir,
        Excalibur,
        Wraith_Stone,
        Scion1,
        Scion2,
        Scion3,
        
        Weapon_AK_Rifle,
        Weapon_Assault_Rifle,
        Weapon_Handgun,
        Weapon_Shotgun,
        Weapon_Speargun,
        Weapon_Tranquilizer,
        Weapon_Uzi,
        Weapon_Grenade,

        Croft_Manor_Hall,
        Croft_Manor_Hall_LQ,
        Croft_Manor_Back,
        Yacht,
        Ship,
        Glass_Cage,
        Ship_Natla_Room,
        Thailand_Mirror_Statue_Left,
        Thailand_Mirror_Statue_Right,

        Foliage_Tree1,
        Foliage_Tree2,
        Foliage_Tree3,
        Foliage_Tree4,

        GoL_Lara,
        GoL_Lara_Biker,
        GoL_Lara_Jungle_Heavy,
        GoL_Lara_Jungle_Shorts,
        GoL_Lara_Legend,
        GoL_Doppelganger,

        GoL_Chompy,
        GoL_Totec,
        GoL_Xolotl,
        GoL_Fire_Lizard,
        GoL_Poison_Lizard,
        GoL_Fire_Shaman,
        GoL_Poison_Shaman,
        GoL_Shield_Gatekeeper,
        GoL_Brute_Minion,
        GoL_Small_Minion,
        GoL_Poison_Minion,
        GoL_TRex,
        GoL_Skeleton,
        GoL_Poison_Gatekeeper,
        GoL_Shield_Demon,

        SkyDome_Thailand_Sea,

        Dummy,
        ExternObj,
    }

    public class ItemFactory {
        
        public static Item GetItem(Game game, ItemType type) {
            switch (type) {
                
                case ItemType.Lara_Jungle_Shorts:
                    return new LaraJungleShorts(game);

                case ItemType.Lara_Jungle_Pants:
                    return new LaraJunglePants(game);

                case ItemType.Lara_Jungle_Heavy:
                    return new LaraJungleHeavy(game);
                
                case ItemType.Lara_WetSuit:
                    return new LaraWetSuit(game);

                case ItemType.Lara_WetSuit_NoGear:
                    return new LaraWetSuitNoGear(game);

                case ItemType.Lara_DrySuit:
                    return new LaraDrySuit(game);

                case ItemType.Lara_Bathing_Suit:
                    return new LaraBathingSuit(game);

                case ItemType.Lara_Bathing_Suit_NoGear:
                    return new LaraBathingSuitNoGear(game);

                case ItemType.Lara_Casual:
                    return new LaraCasual(game);

                case ItemType.Lara_Snow_Light:
                    return new LaraSnowLight(game);

                case ItemType.Lara_Snow_Heavy:
                    return new LaraSnowHeavy(game);

                case ItemType.Lara_DLC_Bikini_BlackWhite:
                    return new LaraDLCBikiniBlackWhite(game);

                case ItemType.Lara_DLC_Bikini_Blue:
                    return new LaraDLCBikiniBlue(game);

                case ItemType.Lara_DLC_Bikini_Camo:
                    return new LaraDLCBikiniCamo(game);

                case ItemType.Lara_DLC_Bikini_Yellow:
                    return new LaraDLCBikiniYellow(game);

                case ItemType.Lara_DLC_Casual_Explorer:
                    return new LaraDLCCasualExplorer(game);

                case ItemType.Lara_DLC_Classic:
                    return new LaraDLCClassic(game);

                case ItemType.Lara_DLC_Designer_Fashion_Winner:
                    return new LaraDLCDesignerFashionWinner(game);

                case ItemType.Lara_DLC_Designer_Peoples_Choice:
                    return new LaraDLCDesignerPeoplesChoice(game);

                case ItemType.Lara_DLC_DrySuit_Red:
                    return new LaraDLCDrySuitRed(game);

                case ItemType.Lara_DLC_Jungle_Shorts_Grey:
                    return new LaraDLCJungleShortsGrey(game);

                case ItemType.Lara_DLC_Legend:
                    return new LaraDLCLegend(game);

                case ItemType.Lara_DLC_WetSuit_Blue:
                    return new LaraDLCWetSuitBlue(game);


                case ItemType.Natla:
                    return new Natla(game);

                case ItemType.Natla_NoWings:
                    return new NatlaNoWings(game);

                case ItemType.Doppelganger:
                    return new Doppelganger(game);

                case ItemType.Amanda_Light:
                    return new AmandaLight(game);

                case ItemType.Amanda_Heavy:
                    return new AmandaHeavy(game);

                case ItemType.Amelia:
                    return new Amelia(game);

                case ItemType.Alister:
                    return new Alister(game);

                case ItemType.Zip:
                    return new Zip(game);

                case ItemType.Winston:
                    return new Winston(game);

                case ItemType.Braid:
                    return new Braid(game);

                case ItemType.Ponytail:
                    return new Ponytail(game);

                case ItemType.Hair_Amanda:
                    return new HairAmanda(game);

                case ItemType.Hair_Natla:
                    return new HairNatla(game);

                case ItemType.Hair_Alister:
                    return new HairAlister(game);

                case ItemType.Wings:
                    return new Wings(game);

                case ItemType.Tiger1:
                    return new Tiger1(game);

                case ItemType.Tiger2:
                    return new Tiger2(game);

                case ItemType.Panther:
                    return new Panther(game);

                case ItemType.Shark_Blue:
                    return new SharkBlue(game);

                case ItemType.Shark_Greenland:
                    return new SharkGreenland(game);

                case ItemType.Kraken:
                    return new Kraken(game);

                case ItemType.Jellyfish:
                    return new Jellyfish(game);

                case ItemType.Naga_Green:
                    return new NagaGreen(game);

                case ItemType.Naga_Red:
                    return new NagaRed(game);

                case ItemType.Albino_Spider:
                    return new AlbinoSpider(game);

                case ItemType.Diver_Captain:
                    return new DiverCaptain(game);

                case ItemType.Mercenary:
                    return new Mercenary(game);

                case ItemType.Poacher:
                    return new Poacher(game);

                case ItemType.Knight_Thrall:
                    return new KnightThrall(game);

                case ItemType.Mayan_Thrall:
                    return new MayanThrall(game);

                case ItemType.Viking_Thrall:
                    return new VikingThrall(game);

                case ItemType.Panther_Thrall:
                    return new PantherThrall(game);

                case ItemType.Yeti_Thrall:
                    return new YetiThrall(game);

                case ItemType.Yeti_Thrall_NoChains:
                    return new YetiThrallNoChains(game);

                case ItemType.Glasses:
                    return new Glasses(game);

                case ItemType.Recorder:
                    return new Recorder(game);

                case ItemType.Grapple:
                    return new Grapple(game);

                case ItemType.Motorcycle:
                    return new Motorcycle(game);

                case ItemType.Helicopter:
                    return new Helicopter(game);

                case ItemType.Mjolnir:
                    return new Mjolnir(game);

                case ItemType.Excalibur:
                    return new Excalibur(game);

                case ItemType.Wraith_Stone:
                    return new WraithStone(game);

                case ItemType.Scion1:
                    return new Scion1(game);

                case ItemType.Scion2:
                    return new Scion2(game);

                case ItemType.Scion3:
                    return new Scion3(game);

                case ItemType.Weapon_AK_Rifle:
                    return new WeaponAKRifle(game);

                case ItemType.Weapon_Assault_Rifle:
                    return new WeaponAssaultRifle(game);

                case ItemType.Weapon_Handgun:
                    return new WeaponHandgun(game);

                case ItemType.Weapon_Shotgun:
                    return new WeaponShotgun(game);

                case ItemType.Weapon_Speargun:
                    return new WeaponSpeargun(game);

                case ItemType.Weapon_Tranquilizer:
                    return new WeaponTranquilizer(game);

                case ItemType.Weapon_Uzi:
                    return new WeaponUzi(game);

                case ItemType.Weapon_Grenade:
                    return new WeaponGrenade(game);

                case ItemType.Croft_Manor_Hall:
                    return new CroftManorHall(game);

                case ItemType.Croft_Manor_Hall_LQ:
                    return new CroftManorHallLQ(game);

                case ItemType.Croft_Manor_Back:
                    return new CroftManorBack(game);

                case ItemType.Yacht:
                    return new Yacht(game);

                case ItemType.Ship:
                    return new Ship(game);

                case ItemType.Glass_Cage:
                    return new GlassCage(game);

                case ItemType.Ship_Natla_Room:
                    return new ShipNatlaRoom(game);

                case ItemType.Thailand_Mirror_Statue_Left:
                    return new ThailandMirrorStatueLeft(game);

                case ItemType.Thailand_Mirror_Statue_Right:
                    return new ThailandMirrorStatueRight(game);

                case ItemType.Foliage_Tree1:
                    return new FoliageTree1(game);

                case ItemType.Foliage_Tree2:
                    return new FoliageTree2(game);

                case ItemType.Foliage_Tree3:
                    return new FoliageTree3(game);

                case ItemType.Foliage_Tree4:
                    return new FoliageTree4(game);

                case ItemType.GoL_Chompy:
                    return new GoLChompy(game);

                case ItemType.GoL_Totec:
                    return new GoLTotec(game);

                case ItemType.GoL_Xolotl:
                    return new GoLXolotl(game);

                case ItemType.GoL_Fire_Lizard:
                    return new GoLFireLizard(game);

                case ItemType.GoL_Poison_Lizard:
                    return new GoLPoisonLizard(game);

                case ItemType.GoL_Fire_Shaman:
                    return new GoLFireShaman(game);

                case ItemType.GoL_Poison_Shaman:
                    return new GoLPoisonShaman(game);

                case ItemType.GoL_Shield_Gatekeeper:
                    return new GoLShieldGatekeeper(game);

                case ItemType.GoL_Brute_Minion:
                    return new GoLBruteMinion(game);

                case ItemType.GoL_Small_Minion:
                    return new GoLSmallMinion(game);

                case ItemType.GoL_Poison_Minion:
                    return new GoLPoisonMinion(game);

                case ItemType.GoL_TRex:
                    return new GoLTRex(game);

                case ItemType.GoL_Skeleton:
                    return new GoLSkeleton(game);

                case ItemType.GoL_Poison_Gatekeeper:
                    return new GoLPoisonGatekeeper(game);

                case ItemType.GoL_Shield_Demon:
                    return new GoLShieldDemon(game);

                case ItemType.GoL_Lara:
                    return new GoLLara(game);

                case ItemType.GoL_Lara_Biker:
                    return new GoLLaraBiker(game);

                case ItemType.GoL_Lara_Jungle_Heavy:
                    return new GoLLaraJungleHeavy(game);

                case ItemType.GoL_Lara_Jungle_Shorts:
                    return new GoLLaraJungleShorts(game);

                case ItemType.GoL_Lara_Legend:
                    return new GoLLaraLegend(game);

                case ItemType.GoL_Doppelganger:
                    return new GoLDoppelganger(game);

                case ItemType.Dummy:
                    return new Dummy(game);

                case ItemType.ExternObj:
                    return new ExternObj(game);

                default:
                case ItemType.None:
                    return null;
            }
        }
    }
}
