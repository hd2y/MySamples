using System;
using MyBlog.Domain.Abstractions;
using MyBlog.Domain.Events;

// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Domain.PostAggregate
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Post : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 将无参数构造函数设为私有
        /// </summary>
        protected Post()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="title"></param>
        /// <param name="slug"></param>
        /// <param name="originalContent"></param>
        /// <param name="formatContent"></param>
        /// <param name="editType"></param>
        /// <param name="type"></param>
        /// <param name="createFrom"></param>
        /// <param name="createTime"></param>
        /// <param name="updateTime"></param>
        /// <param name="editTime"></param>
        /// <param name="deleted"></param>
        /// <param name="disallowComment"></param>
        /// <param name="likes"></param>
        /// <param name="status"></param>
        /// <param name="password"></param>
        /// <param name="summary"></param>
        /// <param name="template"></param>
        /// <param name="thumbnail"></param>
        /// <param name="topPriority"></param>
        /// <param name="url"></param>
        /// <param name="visits"></param>
        /// <param name="metaDescription"></param>
        /// <param name="metaKeywords"></param>
        /// <param name="wordCount"></param>
        public Post(string title, string slug, string originalContent, string formatContent, int editType = default,
            int type = default, int createFrom = default, DateTime createTime = default, DateTime updateTime = default,
            DateTime editTime = default, bool deleted = default, bool disallowComment = default,
            long likes = default, int status = 1, string password = "", string summary = default,
            string template = "", string thumbnail = "", int topPriority = default, string url = default,
            long visits = default, string metaDescription = default, string metaKeywords = default,
            long wordCount = default)
        {
            Title = title;
            Slug = slug;
            OriginalContent = originalContent;
            FormatContent = formatContent;
            EditType = editType;
            Type = type;
            CreateFrom = createFrom;
            CreateTime = createTime == default ? DateTime.Now : createTime;
            EditTime = editTime == default ? DateTime.Now : editTime;
            UpdateTime = updateTime == default ? DateTime.Now : updateTime;
            Deleted = deleted;
            DisallowComment = disallowComment;
            Likes = likes;
            Status = status;
            Password = password;
            Summary = summary;
            Template = template;
            Thumbnail = thumbnail;
            TopPriority = topPriority;
            Url = url;
            Visits = visits;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            WordCount = wordCount;
            
            AddDomainEvent(new PostCreatedDomainEvent(this));
        }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; private set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime EditTime { get; private set; }

        /// <summary>
        /// 已删除
        /// </summary>
        public bool Deleted { get; private set; }

        /// <summary>
        /// 创建来源
        /// </summary>
        public int CreateFrom { get; private set; }

        /// <summary>
        /// 禁止评论
        /// </summary>
        public bool DisallowComment { get; private set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public long Likes { get; private set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; private set; }

        /// <summary>
        /// 访问密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 概要
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// 模板
        /// </summary>
        public string Template { get; private set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumbnail { get; private set; }

        /// <summary>
        /// 格式化后内容
        /// </summary>
        public string FormatContent { get; private set; }

        /// <summary>
        /// 编辑类型
        /// </summary>
        public int EditType { get; private set; }

        /// <summary>
        /// 原始内容
        /// </summary>
        public string OriginalContent { get; private set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int TopPriority { get; private set; }

        /// <summary>
        /// 访问链接
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// 浏览量
        /// </summary>
        public long Visits { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string MetaDescription { get; private set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string MetaKeywords { get; private set; }

        /// <summary>
        /// 连字符名称
        /// </summary>
        public string Slug { get; private set; }

        /// <summary>
        /// 字数
        /// </summary>
        public long WordCount { get; private set; }
    }
}