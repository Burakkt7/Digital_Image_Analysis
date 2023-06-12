namespace Digital_Image_Analysis.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime UploadDate { get; set; }
        public int Size { get; set; }
    }
}

