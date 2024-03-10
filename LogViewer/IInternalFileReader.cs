namespace LogViewer
{
    public interface IInternalFileReader
    {
        string ReadFile(Const.InternalConfiguration.FileTypes fileTpe,bool LazyLoad);
    }
}