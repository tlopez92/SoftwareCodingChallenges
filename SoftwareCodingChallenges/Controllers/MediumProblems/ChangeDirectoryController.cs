using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoftwareCodingChallenges.Controllers.MediumProblems
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeDirectoryController : BaseApiController
    {
        /*
         * Problem Statement:
         * You want to be able to change directories from where you currently are into a target directory
         * Create a solution that will show you the path you will need to follow to get to the target directory
         * 
         * Example:
         * Current Directory: root/development/chapter1/section1/lesson2
         * Target Directory: root/development/chapter2/section2/lesson1
         * 
         * Output: ../../../section2/lesson1
         * cd ../../../section2/lesson1
         * Example:
         * Current Directory: root/develpment/chapter1
         * Target Directory: root/development/chatper1/section3/lesson4
         * cd section3/lesson4
         * Output: section3/lesson4
         */
        [HttpPost("/change_directory/")]
        public IActionResult ChangeDirectory(string currentDirectory, string targetDirectory)
        {
            string result = GetRelativeDirectory(currentDirectory, targetDirectory);
            return Ok(result);
        }

        private string GetRelativeDirectory(string currentDirectory, string targetDirectory)
        {
            string[] currentDirectories = currentDirectory.Split('/');
            string[] targetDirectories = targetDirectory.Split('/');

            int currentIndex = 0;
            int targetIndex = 0;

            while (currentIndex < currentDirectories.Length
                && targetIndex < targetDirectories.Length
                && currentDirectories[currentIndex] == targetDirectories[targetIndex])
            {
                currentIndex++;
                targetIndex++;
            }

            List<string> relativeDirectories = new();

            for (int i = currentIndex; i < currentDirectories.Length; i++)
            {
                relativeDirectories.Add("..");
            }

            for (int i = targetIndex; i < targetDirectories.Length; i++)
            {
                relativeDirectories.Add(targetDirectories[i]);
            }

            return string.Join("/", relativeDirectories);
        }
    }
}
