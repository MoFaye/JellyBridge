using System.Text.Json.Serialization;
using Jellyfin.Plugin.JellyBridge.JellyseerrModel;

namespace Jellyfin.Plugin.JellyBridge.BridgeModels;

public class JellyseerrDownloadingItem : DownloadingItem
{
    /// <summary>
    /// Media type as enum - override to use JsonStringEnumConverter
    /// </summary>
    [JsonPropertyName("mediaType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public new JellyseerrModel.MediaType MediaType { get; set; }

    /// <summary>
    /// fork fix: Seerr sends null for estimatedCompletionTime on stalled/queued downloads (e.g. status "warning").
    /// The non-nullable base property made the whole /api/v1/request page fail to deserialize, so JellyBridge
    /// saw zero existing requests ("Failed to deserialize ReadRequests response - got null").
    /// </summary>
    [JsonPropertyName("estimatedCompletionTime")]
    public new DateTimeOffset? EstimatedCompletionTime { get; set; }
}

