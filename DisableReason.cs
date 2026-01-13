namespace ContextMenuPowerTool
{
    public enum DisableReason
    {
        None,
        NameBased,
        LegacyDisable,
        ProgrammaticAccessOnly,
        MissingCommand,
        ShellExMinusClsid,
        BrokenComRegistration
    }
}
