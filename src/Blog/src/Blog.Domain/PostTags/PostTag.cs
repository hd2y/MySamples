﻿using Volo.Abp.Domain.Entities;

namespace Blog.PostTags
{
    /// <summary>
    /// PostTag
    /// </summary>
    public class PostTag : Entity<int>
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// 标签Id
        /// </summary>
        public int TagId { get; set; }
    }
}