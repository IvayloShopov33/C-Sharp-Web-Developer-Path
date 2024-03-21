function solve(browserInformation, actions) {
    TakeAndPerformAllActions(actions, browserInformation);

    PrintAllInformationOfBrowser(browserInformation);
}

function TakeAndPerformAllActions(actions, browserInformation) {
    for (const action of actions) {
        const [currentAction, website] = action.split(' ');
        if (currentAction === 'Open') {
            browserInformation['Open Tabs'].push(website);
            browserInformation['Browser Logs'].push(action);
        } else if (currentAction === "Close" && browserInformation['Open Tabs'].some(openTab => openTab === website)) {
            browserInformation['Open Tabs'] = browserInformation['Open Tabs'].filter(openTab => openTab !== website);
            browserInformation['Recently Closed'].push(website);
            browserInformation['Browser Logs'].push(action);
        } else if (currentAction === 'Clear') {
            browserInformation['Open Tabs'].length = 0;
            browserInformation['Recently Closed'].length = 0;
            browserInformation['Browser Logs'].length = 0;
        }
    }
}

function PrintAllInformationOfBrowser(browserInformation) {
    console.log(browserInformation['Browser Name']);
    console.log(`Open Tabs: ${browserInformation['Open Tabs'].join(', ')}`);
    console.log(`Recently Closed: ${browserInformation['Recently Closed'].join(', ')}`);
    console.log(`Browser Logs: ${browserInformation['Browser Logs'].join(', ')}`);
}

solve({
    "Browser Name": "Google Chrome", "Open Tabs": ["Facebook", "YouTube", "Google Translate"], "Recently Closed": ["Yahoo", "Gmail"],
    "Browser Logs": ["Open YouTube", "Open Yahoo", "Open Google Translate", "Close Yahoo", "Open Gmail", "Close Gmail", "Open Facebook"]
},
    ["Close Facebook", "Open StackOverFlow", "Open Google"]);

solve({
    "Browser Name": "Mozilla Firefox", "Open Tabs": ["YouTube"], "Recently Closed": ["Gmail", "Dropbox"],
    "Browser Logs": ["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"]
},
    ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]);