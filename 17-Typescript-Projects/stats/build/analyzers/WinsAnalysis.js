"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.WinsAnalysis = void 0;
const MatchResult_1 = require("../MatchResult");
class WinsAnalysis {
    constructor(team) {
        this.team = team;
    }
    run(matches) {
        let winCount = 0;
        for (let match of matches) {
            if (match[1] === this.team && match[5] === MatchResult_1.MatchResult.HomeWin)
                winCount++;
            else if (match[2] === this.team && match[5] === MatchResult_1.MatchResult.AwayWin)
                winCount++;
        }
        return `Team ${this.team} won ${winCount} games`;
    }
}
exports.WinsAnalysis = WinsAnalysis;
