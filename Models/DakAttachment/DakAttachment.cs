using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ENothi_Desktop.Models.DakAttachment
{
    public class DakAttachment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_main")]
        public int IsMain { get; set; }

        [JsonProperty("attachment_type")]
        public string AttachmentType { get; set; }

        [JsonProperty("attachment_description")]
        public string AttachmentDescription { get; set; }

        [JsonProperty("content_cover")]
        public string ContentCover { get; set; }

        [JsonProperty("content_body")]
        public string ContentBody { get; set; }

        [JsonProperty("meta_data")]
        public string MetaData { get; set; }

        [JsonProperty("is_summary_nothi")]
        public int IsSummaryNothi { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("user_file_name")]
        public string UserFileName { get; set; }

        [JsonProperty("file_dir")]
        public string FileDir { get; set; }

        [JsonProperty("file_size_in_kb")]
        public double FileSizeInKb { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
    }
}
