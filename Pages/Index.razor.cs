using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entries;
using Microsoft.AspNetCore.Components;

namespace Bertony.Test.Pages
{
    public partial class Index
    {
        [Inject]
        public IPhotoService PhotoService { get; set; }

        public Album[] Albums { get; private set; }
        public Photo[] Photos { get; private set; }
        public PhotoComment[] Comments { get; private set; }

        public int SelectedAlbumId { get; set; }

        public async Task ShowAlbumPhotoAsync()
        {
            Photos = await PhotoService.GetPhotosAsync(SelectedAlbumId);
            StateHasChanged();

        }
        public async Task ShowCommentsAsync(int photoId)
        {
            Comments = await PhotoService.GetCommentsAsync(photoId);
            StateHasChanged();

        }
        
        protected override async Task OnInitializedAsync()
        {
            Albums = await PhotoService.GetAllAlbumsAsync();
            SelectedAlbumId = Albums.First()
                .id;
            await base.OnInitializedAsync();
        }


    }
}
