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
        static const AkUniqueID FS_PLAYER_SWIM = 2996183927U;
        static const AkUniqueID FS_PLAYER_SWIM_SPRINT = 976861018U;
        static const AkUniqueID MUSICSTATE_COMBAT = 3409594792U;
        static const AkUniqueID MUSICSTATE_EXPLORING = 815172640U;
        static const AkUniqueID MUSICSTATE_INITIATE = 2595492705U;
        static const AkUniqueID SFX_3D_EMITTER = 300857671U;
        static const AkUniqueID SFX_3D_EMITTER_STOP = 1821030210U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAMEPLAY_SWITCH
        {
            static const AkUniqueID GROUP = 2702523344U;

            namespace STATE
            {
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
        static const AkUniqueID RTPC_MUSICSTATECOMBAT = 2360084719U;
        static const AkUniqueID RTPC_MUSICSTATEEXPLORE = 4041583320U;
        static const AkUniqueID RTPC_MUSICVOLUMEMASTER = 3732907812U;
        static const AkUniqueID RTPC_PLAYERALIVE = 1824124715U;
        static const AkUniqueID RTPC_SPEEDOFCHARACTER = 2977442876U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
        static const AkUniqueID SOUNDBANK_MUSIC = 474740052U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
