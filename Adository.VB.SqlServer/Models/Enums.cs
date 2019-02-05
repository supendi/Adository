namespace Adository.VB.SqlServer.Models
{
    public enum VBClassModifier
    {
        Public,
        PublicPartial,
        PublicNotInheritable,
        PublicMustInherit,
        Friend,
        FriendNotInheritable,
        FriendMustInherit,
        Shared
    }

    public enum VBMemberModifier
    {
        Dim,
        Private,
        Protected,
        ProtectedOverridable,
        ProtectedOverrides,
        Friend,
        FriendOverridable,
        FriendOverrides,
        Public,
        PublicOverridable,
        PublicOverrides,
    }
}
