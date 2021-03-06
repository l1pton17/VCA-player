﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VKapi.Models
{
    /// <summary>
    ///     Класс, описывающий запись на стене пользователя или сообщества
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VKPost
    {
        public enum PostTypeEnum
        {
            [EnumValue("post")] Post,
            [EnumValue("copy")] Copy,
            [EnumValue("reply")] Reply,
            [EnumValue("postpone")] Postpone,
            [EnumValue("suggest")] Suggest
        }

        /// <summary>
        ///     Идентификатор записи
        /// </summary>
        [JsonProperty("id")]
        public Int64 Id { get; set; }

        /// <summary>
        ///     Идентификатор владельца стены, на которой размещена запись
        /// </summary>
        [JsonProperty("to_id")]
        public Int64 ToId { get; set; }

        /// <summary>
        ///     Идентификатор автора записи
        /// </summary>
        [JsonProperty("from_id")]
        public Int64 FromId { get; set; }

        /// <summary>
        ///     Время публикации записи в формате unixtime
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof (JsonUnixTimeConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        ///     Текст записи
        /// </summary>
        [JsonProperty("text")]
        public String Text { get; set; }

        /// <summary>
        ///     Идентификатор владельца записи, в ответ на которую была оставлена текущая
        /// </summary>
        [JsonProperty("reply_owner_id")]
        public Int64 ReplyOwnerId { get; set; }

        /// <summary>
        ///     Идентификатор записи, в ответ на которую была оставлена текущая
        /// </summary>
        [JsonProperty("reply_post_id")]
        public Int64 ReplyPostId { get; set; }

        /// <summary>
        ///     True, если запись создана с опцией "Только для друзей"
        /// </summary>
        [JsonProperty("friends_only")]
        [JsonConverter(typeof (JsonBoolConvereter))]
        public Boolean FriendsOnly { get; set; }

        /// <summary>
        ///     Информация о комментариях к записи
        /// </summary>
        [JsonProperty("comments")]
        public VKComments Comments { get; set; }

        /// <summary>
        ///     Информация о лайках к записи
        /// </summary>
        [JsonProperty("likes")]
        public VKLikes Likes { get; set; }

        /// <summary>
        ///     Информация о репостах записи
        /// </summary>
        [JsonProperty("reposts")]
        public VKReposts Reposts { get; set; }

        /// <summary>
        ///     Тип записи, может принимать следующие значения:
        ///     <value>post</value>
        ///     ,
        ///     <value>copy</value>
        ///     ,
        ///     <value>reply</value>
        ///     ,
        ///     <value>postpone</value>
        ///     ,
        ///     <value>suggest</value>
        /// </summary>
        [JsonProperty("post_type")]
        [JsonConverter(typeof (JsonEnumConverter<PostTypeEnum>))]
        public PostTypeEnum PostType { get; set; }

        /// <summary>
        ///     Информация о вложениях записи
        /// </summary>
        [JsonProperty("attachments")]
        public List<VKAttachment> Attachments { get; set; }

        /// <summary>
        ///     Информация о местоположении
        /// </summary>
        [JsonProperty("geo")]
        public VKGeo Geo { get; set; }

        /// <summary>
        ///     Идентификатор автора, если запись была опубликована от имени сообщества и подписана пользователем
        /// </summary>
        [JsonProperty("signer_id")]
        public Int64 SignerId { get; set; }

        /// <summary>
        ///     Время публикации записи-оригинала в формате unixtime (если запись является копией записи с чужой стены)
        /// </summary>
        [JsonProperty("copy_post_date")]
        [JsonConverter(typeof (JsonUnixTimeConverter))]
        public DateTime CopyPostDate { get; set; }

        /// <summary>
        ///     Тип записи-оригинала (если запись является копией записи с чужой стены)
        /// </summary>
        [JsonProperty("copy_post_type")]
        public String CopyPostType { get; set; }

        /// <summary>
        ///     Идентификатор владельца стены, у которого была скопирована запись (если запись является копией записи с чужой
        ///     стены)
        /// </summary>
        [JsonProperty("copy_owner_id")]
        public Int64 CopyOwnerId { get; set; }

        /// <summary>
        ///     Идентификатор скопированной записи на стене ее владельца (если запись является копией записи с чужой стены)
        /// </summary>
        [JsonProperty("copy_post_id")]
        public Int64 CopyPostId { get; set; }

        /// <summary>
        ///     Текст комментария, добавленного при копировании (если запись является копией записи с чужой стены)
        /// </summary>
        [JsonProperty("copy_text")]
        public String CopyText { get; set; }
    }
}