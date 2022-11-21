mn
const postService = function (url, data) {
    var filename = "";
    fetch(url, {
        method: 'POST', // or 'PUT'
        headers: {
            'Content-type': 'application/json',
        },
        body: JSON.stringify(data)
    }).then((res) => {
        var disposition = res.headers.get('Content-Disposition');
        if (disposition && disposition.indexOf('attachment') !== -1) {
            var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
            var matches = filenameRegex.exec(disposition);
            if (matches != null && matches[1]) filename = matches[1].replace(/['"]/g, '');
        }
        return res.blob();
    }).then(blob => {
        var url = window.URL.createObjectURL(blob);
        var a = document.createElement('a');
        a.href = url;
        a.download = filename;
        a.dispatchEvent(new MouseEvent('click'));
    }).catch(error => console.error('Error:', error));
}