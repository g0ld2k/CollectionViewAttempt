using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CollectionViewAttempt
{
	public class ItemType
	{
		public int LookupId { get; set; }
		public string LookupValue { get; set; }
	}

	public class FeaturedArticles
	{
		public string GUID { get; set; }
		public int ID { get; set; }
		public string Title { get; set; }
		public string Select { get; set; }
		public string Name { get; set; }
		public string Created { get; set; }
		public string Modified { get; set; }

		[JsonProperty("Modified By")]
		public string ModifiedBy { get; set; }

		[JsonProperty("Created By")]
		public string CreatedBy { get; set; }

		[JsonProperty("URL Path")]
		public List<object> URLPath { get; set; }

		[JsonProperty("File Type")]
		public string FileType { get; set; }

		[JsonProperty("HTML File Type")]
		public object HTMLFileType { get; set; }

		[JsonProperty("Item Type")]
		public List<ItemType> ItemType { get; set; }

		[JsonProperty("Encoded Absolute URL")]
		public string EncodedAbsoluteURL { get; set; }

		public string Preview { get; set; }
		public object Keywords { get; set; }

		[JsonProperty("Thumbnail URL")]
		public string ThumbnailURL { get; set; }

		[JsonProperty("Web Image URL")]
		public string WebImageURL { get; set; }

		[JsonProperty("Thumbnail Preview")]
		public string ThumbnailPreview { get; set; }

		[JsonProperty("Thumbnail Exists")]
		public bool ThumbnailExists { get; set; }

		[JsonProperty("Preview Exists")]
		public bool PreviewExists { get; set; }

		public string Width { get; set; }

		[JsonProperty("Picture Size")]
		public string PictureSize { get; set; }
		public string Height { get; set; }
		public object Comments { get; set; }
		public string Author { get; set; }

		[JsonProperty("Date Picture Taken")]
		public string DatePictureTaken { get; set; }
		public object Copyright { get; set; }
		public bool Active { get; set; }
		public object RoutingRuleDescription { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
		public string Hyperlink { get; set; }
	}
}

