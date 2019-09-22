namespace ServiceBlock.Options
{
    public class ServiceBlock
    {
        public Security? Security { get; set; }

        public bool SecurityEnabled => Security != null;
    }
}