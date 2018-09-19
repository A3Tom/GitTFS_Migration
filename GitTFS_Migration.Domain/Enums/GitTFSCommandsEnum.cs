namespace GitTFS_Migration.Domain.Enums
{
    public enum GitTFSCommandsEnum
    {
        CloneFromTFS = 1,
        AddOriginRemote = 2,
        GenerateDevelopBranch = 3,
        GenerateGitIgnore = 4,
        AddGitIgnoreToRepository = 5,
        CommitGitIgnore = 6,
        PushOriginRemote = 7
    }
}
