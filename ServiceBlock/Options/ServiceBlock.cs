namespace ServiceBlock.Options
{
    class ServiceBlock
    {
        public Security? Security { get; set; }

        public bool SecurityEnabled => Security != null;
    }
}