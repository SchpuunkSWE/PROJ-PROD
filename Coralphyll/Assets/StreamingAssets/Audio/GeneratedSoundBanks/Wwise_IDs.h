/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BACKGROUND_AMBIENCE = 2160339820U;
        static const AkUniqueID BACKGROUND_AMBIENCE_2 = 50319475U;
        static const AkUniqueID CHAR_DASH = 667507884U;
        static const AkUniqueID CUTSCENE_LEVEL1_AMBIENCE = 2212933930U;
        static const AkUniqueID CUTSCENE_LEVEL1_VOICE = 3304948164U;
        static const AkUniqueID CUTSCENE_LEVEL2_AMBIENCE = 2945618175U;
        static const AkUniqueID CUTSCENE_LEVEL2_SHARKBITE = 3451548568U;
        static const AkUniqueID CUTSCENE_LEVEL2_VOICE = 1672897699U;
        static const AkUniqueID CUTSCENE_LEVEL4_STINGER = 3295537989U;
        static const AkUniqueID CUTSCENE_PLAYCREDITS = 650132800U;
        static const AkUniqueID FISHEAT = 2968903799U;
        static const AkUniqueID FS_PLAYER_SWIM = 2996183927U;
        static const AkUniqueID FS_PLAYER_SWIM_SPRINT = 976861018U;
        static const AkUniqueID GARBAGE_PLAY = 143285903U;
        static const AkUniqueID GARBAGE_STOP = 2902390157U;
        static const AkUniqueID MUSICSTATE_COMBAT = 3409594792U;
        static const AkUniqueID MUSICSTATE_EXPLORING = 815172640U;
        static const AkUniqueID MUSICSTATE_MAINMENU = 144300286U;
        static const AkUniqueID MUSICSTATE_STARTOFLEVEL = 4090089807U;
        static const AkUniqueID NEW_EVENT = 3050945240U;
        static const AkUniqueID NPC_DROPOFF = 3939156573U;
        static const AkUniqueID NPC_ENEMY_SHARK = 3909403805U;
        static const AkUniqueID NPC_ENEMY_SHARK_STOP = 3192907696U;
        static const AkUniqueID NPC_FRIENDLY_BLUE = 2396901519U;
        static const AkUniqueID NPC_FRIENDLY_BLUE_STOP = 1686688698U;
        static const AkUniqueID NPC_FRIENDLY_FISH_GENERIC = 4098783091U;
        static const AkUniqueID NPC_FRIENDLY_FISH_GENERIC_STOP = 203293054U;
        static const AkUniqueID NPC_FRIENDLY_PICKUP = 679089271U;
        static const AkUniqueID NPC_FRIENDLY_RED = 54285700U;
        static const AkUniqueID NPC_FRIENDLY_RED_STOP = 3941370595U;
        static const AkUniqueID NPC_FRIENDLY_YELLOW = 2379275139U;
        static const AkUniqueID NPC_FRIENDLY_YELLOW_STOP = 1435982318U;
        static const AkUniqueID ONESHOT_CORALCOMPLETED = 1671773852U;
        static const AkUniqueID ONESHOT_ENEMYALERT = 1157870456U;
        static const AkUniqueID ONESHOT_SEACREATURE = 4269048160U;
        static const AkUniqueID SFX_3D_EMITTER_FRIENDLY_FISH_1 = 2090281704U;
        static const AkUniqueID SFX_3D_EMITTER_FRIENDLY_FISH_1_STOP = 3857701063U;
        static const AkUniqueID SFX_3D_EMITTER_WATER_SPROUT = 1644260233U;
        static const AkUniqueID SFX_3D_EMITTER_WATER_SPROUT_STOP = 1255022652U;
        static const AkUniqueID SHARKHUFF = 638605449U;
        static const AkUniqueID SKIPCUTSCENE = 3576905580U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace EFFECTS
        {
            static const AkUniqueID GROUP = 1942696649U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID REVERBON = 303990094U;
            } // namespace STATE
        } // namespace EFFECTS

        namespace GAMEPLAY_SWITCH
        {
            static const AkUniqueID GROUP = 2702523344U;

            namespace STATE
            {
                static const AkUniqueID MAINMENU = 3604647259U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace GAMEPLAY_SWITCH

        namespace MUSIC_STATE
        {
            static const AkUniqueID GROUP = 3826569560U;

            namespace STATE
            {
                static const AkUniqueID COMBAT = 2764240573U;
                static const AkUniqueID DEFEAT = 1593864692U;
                static const AkUniqueID EXPLORING = 1823678183U;
                static const AkUniqueID MAINMENU = 3604647259U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID VICTORY = 2716678721U;
            } // namespace STATE
        } // namespace MUSIC_STATE

        namespace PLAYERLIFE
        {
            static const AkUniqueID GROUP = 444815956U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace PLAYERLIFE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace GAMEPLAY_SWITCH
        {
            static const AkUniqueID GROUP = 2702523344U;

            namespace SWITCH
            {
            } // namespace SWITCH
        } // namespace GAMEPLAY_SWITCH

        namespace PLAYER_STATUS
        {
            static const AkUniqueID GROUP = 1647429799U;

            namespace SWITCH
            {
                static const AkUniqueID DEFEATED = 2791675679U;
                static const AkUniqueID HEALTHY = 2874639328U;
            } // namespace SWITCH
        } // namespace PLAYER_STATUS

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID RTPC_AMBIENCEVOLUME = 3644905565U;
        static const AkUniqueID RTPC_MASTERVOLUME = 2582501215U;
        static const AkUniqueID RTPC_MUSICSTATECOMBAT = 2360084719U;
        static const AkUniqueID RTPC_MUSICSTATEEXPLORE = 4041583320U;
        static const AkUniqueID RTPC_MUSICVOLUME = 2378823330U;
        static const AkUniqueID RTPC_MUSICVOLUMEMASTER = 3732907812U;
        static const AkUniqueID RTPC_PLAYERALIVE = 1824124715U;
        static const AkUniqueID RTPC_PLAYERDEPTH = 3095049895U;
        static const AkUniqueID RTPC_REVERB = 4143461479U;
        static const AkUniqueID RTPC_SFXVOLUME = 2644490154U;
        static const AkUniqueID RTPC_SPEEDOFCHARACTER = 2977442876U;
    } // namespace GAME_PARAMETERS

    namespace TRIGGERS
    {
        static const AkUniqueID FISH_EATEN = 1787465173U;
    } // namespace TRIGGERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID LARGESONGS = 4196917472U;
        static const AkUniqueID MAIN = 3161908922U;
        static const AkUniqueID TEST = 3157003241U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID REVERB_AMBIENCE = 306711088U;
        static const AkUniqueID REVERB_MUSIC = 301991745U;
        static const AkUniqueID REVERB_SFX = 3434922741U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
