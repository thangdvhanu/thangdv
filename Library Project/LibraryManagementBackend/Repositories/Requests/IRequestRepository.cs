using System.Collections.Generic;
using LibraryManagementBackend.Models.Entity;

namespace LibraryManagementBackend.Repositoties.Requests
{
  public interface IRequestRepository : IRepository<BorrowingRequest>
  {
    int Create(int userId, List<int> bookIds);
    void Approve(int userId, BorrowingRequest request);
    void Reject(int userId, BorrowingRequest request);
    IEnumerable<BorrowingRequest> FilterByStatus(int userId);
  }
}
