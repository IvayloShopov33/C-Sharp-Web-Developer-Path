function solve(meetingsRequested) {
    const meetings = {};
    for (let i = 0; i < meetingsRequested.length; i++) {
        const [weekday, personName] = meetingsRequested[i].split(' ');

        if (meetings[weekday]) {
            console.log(`Conflict on ${weekday}!`);
        } else {
            meetings[weekday] = personName;
            console.log(`Scheduled for ${weekday}`);
        }
    }

    for (const meeting in meetings) {
        console.log(`${meeting} -> ${meetings[meeting]}`);
    }
}

solve(['Friday Bob', 'Saturday Ted', 'Monday Bill', 'Monday John', 'Wednesday George']);
solve(['Monday Peter', 'Wednesday Bill', 'Monday Tim', 'Friday Tim']);