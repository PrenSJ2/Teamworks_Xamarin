using System.Threading.Tasks;
using Teamworks_2.Droid;
using Teamworks_2.Models;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(ImageService))]
namespace Teamworks_2.Droid
{
    public class ImageService : IImageService
    {
        public async Task<string> PickImageAsync()
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var file = await MediaPicker.PickPhotoAsync();
                return file?.FullPath;
            }
            else
            {
                // Capture is not supported
                return null;
            }
        }
    }
}



