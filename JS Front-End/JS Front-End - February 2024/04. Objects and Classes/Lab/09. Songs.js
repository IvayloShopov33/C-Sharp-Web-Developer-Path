function solve(songsDetails) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }

        printName() {
            console.log(this.name);
        }
    }

    let songs = [];
    const songsCount = songsDetails.shift();
    for (let i = 0; i < songsCount; i++) {
        const [typeList, name, time] = songsDetails[i].split('_');
        songs.push(new Song(typeList, name, time));
    }

    const desiredTypeList = songsDetails.pop();
    if (desiredTypeList !== 'all') {
        songs = songs.filter(song => song.typeList === desiredTypeList);
    }

    for (const song of songs) {
        song.printName();
    }
}

solve([3, 'favourite_DownTown_3:14', 'favourite_Kiss_4:16', 'favourite_Smooth Criminal_4:01', 'favourite']);
solve([4, 'favourite_DownTown_3:14', 'listenLater_Andalouse_3:24', 'favourite_In To The Night_3:58', 'favourite_Live It Up_3:48', 'listenLater']);
solve([2, 'like_Replay_3:15', 'ban_Photoshop_3:48', 'all']);