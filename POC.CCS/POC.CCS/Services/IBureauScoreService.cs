namespace POC.CCS.Services
{
    using POC.CCS.Models;
    using System.Collections.Generic;

    public interface IBureauScoreService
    {
        IEnumerable<BureauScore> GeBureauScore();

        BureauScore GetBureauScore(int score);
    }
}
