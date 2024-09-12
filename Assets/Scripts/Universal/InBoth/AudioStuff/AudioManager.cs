using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public UniversalAudioLibrary UniversalAudioLibrary;
    public SlumsAudioLibrary SlumsAudioLibrary;
    public ApartmentAudioLibrary ApartmentAudioLibrary;
    public RuralAudioLibrary RuralAudioLibrary;
    public CorporateAudioLibrary CorporateAudioLibrary;
    public enum UniversalClipTags
    {
        Gunfire,
        PlayerHurt,
        PlayerJump,
        PlayerWalk,
        PlayerLowHealth,
        EnemyBasicMelee,
        MenuClick,
        MenuOver
    }
    public enum SlumsClipTags
    {
        //Cat level
        FishJump,
        FishLand,
        FishHurt,
        FishDie,

        //Addict level
        NeedleJump,
        NeedleShoot,
        NeedleHurt,
        NeedleDeath,
        
        //Dealer level
        BillBossDeath,
        BillBossFlick,
        BillBossSwarm,
        BillPaperDeath

    }
    
    public enum ApartmentClipTags
    {
        //Mother level
        KneeManKneeShot,
        KneeManFall,
        KneeManHurt,
        KneeManHeadOpen,
        KneeManDeath,

        //Daughter level
        PillBottleRun,
        PillBottleThrow,
        PillBottleHurt,
        PillBottleDeath,

        PillBattleCry,
        PillDeath,

        //Father level
        MrCigsRageUp,
        MrCigsRageDown,
        MrCigsAttack,
        MrCigsDeath
    }
    
    public enum CorporateClipTags
    {
        //Faceless Level
        PickUp,
        FacelessSound1,
        FaceLessSound2,
        FacelessSound3,
        FacelessSound4,
        FacelessSound5,
        FacelessSound6,
        FacelessSound7,
        BossSpawn1,
        BossSpawn2,
        BossSpawn3,
        BossSpawn4,

        // For Cocaine Level,
        PuffNoise,
        Sniffing,
        CokeDeath,
    }
    public enum RuralClipTags
    {
        //Farmer Level
        FireExtenguish,
        FireGrow,

        //Farmer's son Level
        TargetDeath,
        DoorCreak,
        DoorSlam,
        Moo,

        //Cow Level
        Whoosh,
        PlayerHitByBucket,
        Splash,
        BucketLand,

    }

    public void OnEnable()
    {
        GameEvents.OnUniversalplayAudio += UniversalOnPlayAudio;
        GameEvents.OnSlumsplayAudio += SlumsOnPlayAudio;
        GameEvents.OnRuralplayAudio += RuralOnPlayAudio;
        GameEvents.OnApartmentplayAudio += ApartmentOnPlayAudio;
        GameEvents.OnCorporateplayAudio += CorporateOnPlayAudio;
    }
    public void OnDisable()
    {
        GameEvents.OnUniversalplayAudio -= UniversalOnPlayAudio;
        GameEvents.OnSlumsplayAudio -= SlumsOnPlayAudio;
        GameEvents.OnRuralplayAudio -= RuralOnPlayAudio;
        GameEvents.OnApartmentplayAudio -= ApartmentOnPlayAudio;
        GameEvents.OnCorporateplayAudio -= CorporateOnPlayAudio;
    }
    private void UniversalOnPlayAudio(AudioSource source, UniversalClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }

        UniversalAudioClip libraryClip = UniversalAudioLibrary.audioClips.FirstOrDefault(clip => clip.UniversalClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);

    }
    private void SlumsOnPlayAudio(AudioSource source, SlumsClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        SlumsAudioClip libraryClip = SlumsAudioLibrary.audioClips.FirstOrDefault(clip => clip.SlumsClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }
    
    private void ApartmentOnPlayAudio(AudioSource source, ApartmentClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        ApartmentAudioClip libraryClip = ApartmentAudioLibrary.audioClips.FirstOrDefault(clip => clip.ApartmentClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }
    
    private void CorporateOnPlayAudio(AudioSource source, CorporateClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        CorporateAudioClip libraryClip = CorporateAudioLibrary.audioClips.FirstOrDefault(clip => clip.CorporateClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }
    
    private void RuralOnPlayAudio(AudioSource source, RuralClipTags clipTag)
    {
        if (source == null)
        {
            Debug.LogError("No Audio Source");
            return;
        }
        RuralAudioClip libraryClip = RuralAudioLibrary.audioClips.FirstOrDefault(clip => clip.RuralClipTag == clipTag);

        libraryClip.PlayClip(source, libraryClip.audioClip, libraryClip.Loop, libraryClip.Pitch, libraryClip.Volume);
    }
}