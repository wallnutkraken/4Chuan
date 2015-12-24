using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Jackie4Chuan
{
    class Post
    {
        public int Number { get; set; }
        public int ReplyTo { get; set; }
        public bool IsSticky { get; set; }
        public bool IsClosed { get; set; }
        public bool IsArchived { get; set; }
        [JsonProperty("now")]
        public string PostTime { get; set; }
        [JsonProperty("time")]
        public int UnixTime { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("trip")]
        public string Tripcode { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("capcode")]
        public string CapCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("sub")]
        public string Subject { get; set; }
        [JsonProperty("com")]
        public string Comment { get; set; }
        [JsonProperty("tim")] 
        public int RenamedFilename { get; set; }
        [JsonProperty("filename")]
        public string OriginalFilename { get; set; }
        [JsonProperty("ext")]
        public string FileExtension { get; set; }
        [JsonProperty("fsize")] 
        public int FileSize { get; set; }
        [JsonProperty("md5")] 
        public string Md5Hash { get; set; }
        [JsonProperty("w")]
        public int ImageWidth { get; set; }
        [JsonProperty("h")] 
        public int ImageHeight { get; set; }
        [JsonProperty("tn_h")]
        public int ThumbnailHeight { get; set; }
        [JsonProperty("tn_w")] 
        public int ThumbnailWidth { get; set; }
        [JsonProperty("filedeleted")]
        public bool FileDeleted { get; set; }
        [JsonProperty("spoiler")]
        public bool IsSpoiler { get; set; }

        /// <summary>
        /// I have NO fucking idea what a custom spoiler is
        /// </summary>
        [JsonProperty("custom_spoiler")]
        public int CustomSpoiler { get; set; }
    }
}
