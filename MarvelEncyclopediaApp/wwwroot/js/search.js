let html;

function renderData(item) {
    var selectedOption = $('#searchType').find(":selected").val();
    var selectedUrl = "";

    switch (selectedOption) {
        case "characters":
            selectedUrl = `<a href="/view/characters/${item.id}"><h5 class="card-title text-center">${item.name}</h5></a>`
            break;
        case "comics":
            selectedUrl = `<a href="/view/comics/${item.id}"><h5 class="card-title text-center">${item.title}</h5></a>`
            break;
        case "events":
            selectedUrl = `<a href="/view/events/${item.id}"><h5 class="card-title text-center">${item.title}</h5></a>`
            break;
        case "creators":
            selectedUrl = `<a href="/view/creators/${item.id}"><h5 class="card-title text-center">${item.fullName}</h5></a>`
            break;
        case "series":
            selectedUrl = `<a href="/view/series/${item.id}"><h5 class="card-title text-center">${item.title}</h5></a>`
            break;
        case "stories":
            selectedUrl = `<a href="/view/stories/${item.id}"><h5 class="card-title text-center">${item.title}</h5></a>`
            break;
    }
    
    html +=
        `
                <div class="col mb-4">
                    <div class="card h-100 border-0 shadow">
                        <img src="${item.thumbnail.path}.${item.thumbnail.extension}" class="card-img-top" style="object-fit: cover; height: 300px">
                        <div class="card-body">
                            ${selectedUrl}
                        </div>
                    </div>
                </div>
        `;
}

$(document).ready(function () {

    $("#handleSearch").click(function () {
        var selectedOption = $('#searchType').find(":selected").val();
        var selectedUrl = "";
        html = "";

        switch (selectedOption) {
            case "characters":
                selectedUrl = "Index?handler=ListsOfCharacters";
                break;
            case "comics":
                selectedUrl = "Index?handler=ListsOfComics";
                break;
            case "events":
                selectedUrl = "Index?handler=ListsOfEvents";
                break;
            case "creators":
                selectedUrl = "Index?handler=ListsOfCreators";
                break;
            case "series":
                selectedUrl = "Index?handler=ListsOfSeries";
                break;
            case "stories":
                selectedUrl = "Index?handler=ListsOfStories";
                break;
        }

        $.ajax({
            type: 'GET',
            url: selectedUrl,
            data: {
                'givenTerm': $("#searchTerm").val()
            },
            headers: {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (response) {                
                let resultsData = response.data;
                resultsData.forEach(renderData);
                $('#heroesContainer').html(html);
                $('#resultsCount').html(`<p>About ${resultsData.length} results</p>`);
            },
            error: (error) => {
                console.log(JSON.stringify(error));
            }
        })
    });
});