namespace CMSShared
{
    public enum EAdditionalRoleFlags : long
    {
          None                = 0
        , Singer              = 1 << 0
        , PoetryReciter       = 1 << 1
        , PrayerPreacher      = 1 << 2
        , Preacher            = 1 << 3
        , OrderKeeper         = 1 << 4
        , KindergartenTeacher = 1 << 5
    }
}
