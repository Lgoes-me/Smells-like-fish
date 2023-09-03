mergeInto(LibraryManager.library, {

    SaveItem: function (item, content) {
        localStorage.setItem(item, content);
    },
    
    LoadItem: function (item){
        return localStorage.getItem(item);
    }
});