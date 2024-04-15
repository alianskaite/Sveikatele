using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using tp_sveikatele.Models;

namespace YourNamespace.Controllers
{
    public class CommunityController : Controller
    {
        // In-memory collections to store posts and comments
        private static List<Post> _posts = new List<Post>();
        private static Dictionary<int, List<Comment>> _commentsByPostId = new Dictionary<int, List<Comment>>();

        // GET: /Community/Index
        public IActionResult Index()
        {
            // Retrieve posts with their associated comments
            var postsWithComments = new List<Post>();
            foreach (var post in _posts)
            {
                var comments = _commentsByPostId.ContainsKey(post.Id) ? _commentsByPostId[post.Id] : new List<Comment>();
                post.Comments = comments; // Add comments to each post
                postsWithComments.Add(post);
            }

            // Display a list of posts with their associated comments
            return View(postsWithComments);
        }

        // GET: /Community/Details/{postId}
        public IActionResult Details(int postId)
        {
            // Find the post by postId
            var post = _posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound();
            }

            // Retrieve comments for the post
            var comments = _commentsByPostId.ContainsKey(postId) ? _commentsByPostId[postId] : new List<Comment>();

            // Display post details with comments
            ViewBag.Comments = comments;
            return View(post);
        }

        // GET: /Community/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Community/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                // Assign a unique ID to the post
                post.Id = _posts.Count + 1;
                // Add the post to the collection
                _posts.Add(post);
                // Redirect to the index action with updated list of posts
                return RedirectToAction(nameof(Index), _posts);
            }
            return View(post);
        }

        // GET: /Community/Edit/{postId}
        public IActionResult Edit(int postId)
        {
            // Find the post by postId
            var post = _posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: /Community/Edit/{postId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int postId, Post post)
        {
            if (postId != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update the post in the collection
                var existingPost = _posts.FirstOrDefault(p => p.Id == postId);
                if (existingPost != null)
                {
                    existingPost.Title = post.Title;
                    existingPost.Content = post.Content;
                    // Update other properties as needed
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: /Community/Delete/{postId}
        public IActionResult Delete(int postId)
        {
            // Find the post by postId
            var post = _posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: /Community/Delete/{postId}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int postId)
        {
            // Remove the post from the collection
            var post = _posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                _posts.Remove(post);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: /Community/AddComment/{postId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int postId, Comment comment)
        {
            if (ModelState.IsValid)
            {
                // Find the post by postId
                var post = _posts.FirstOrDefault(p => p.Id == postId);
                if (post != null)
                {
                    // Assign a unique ID to the comment
                    comment.Id = _commentsByPostId.ContainsKey(postId) ? _commentsByPostId[postId].Count + 1 : 1;
                    // Add the comment to the collection
                    if (!_commentsByPostId.ContainsKey(postId))
                    {
                        _commentsByPostId[postId] = new List<Comment>();
                    }
                    _commentsByPostId[postId].Add(comment);
                }
                return RedirectToAction(nameof(Details), new { postId = postId });
            }
            return RedirectToAction(nameof(Details), new { postId = postId });
        }
    }
}
