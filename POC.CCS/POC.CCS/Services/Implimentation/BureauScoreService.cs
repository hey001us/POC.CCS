namespace POC.CCS.Services.Implimentation
{
    using System.Collections.Generic;
    using POC.CCS.Data.Interface;
    using POC.CCS.Models;

    public class BureauScoreService : IBureauScoreService
    {
        private readonly IBureauScoreRepository repository;

        public BureauScoreService(IBureauScoreRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<BureauScore> GeBureauScore()
        {
            return this.repository.GetAll();
        }

        public BureauScore GetBureauScore(int score)
        {
            return this.repository.Get(x => score >= x.Start && score <= x.End);
        }
    }
}
