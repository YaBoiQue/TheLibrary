using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RapidTireEstimates.Data;
using RapidTireEstimates.Interfaces;
using RapidTireEstimates.Models;
using RapidTireEstimates.Repositories;
using RapidTireEstimates.Specifications;
using RapidTireEstimates.ViewModels;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.Controllers
{
    public class EstimateCommentsController : Controller
    {
        private readonly IEstimateCommentRepository _estimateCommentRepository;

        public EstimateCommentsController(IEstimateCommentRepository estimateCommentRepository)
        {
            _estimateCommentRepository = estimateCommentRepository;
        }

        // GET: EstimateComments
        public async Task<IActionResult> Index(EstimateCommentViewModel estimateCommentViewModel)
        {
            string filterBy = "";
            SortByParameter orderBy = SortByParameter.NameASC;
            if (estimateCommentViewModel != null)
            {
                filterBy = estimateCommentViewModel.FilterBy;
                orderBy = estimateCommentViewModel.SortBy;
            }
            estimateCommentViewModel ??= new EstimateCommentViewModel();

            estimateCommentViewModel.EstimateComments = await _estimateCommentRepository.GetAll(new GetEstimateCommentsFilteredBy(filterBy), new GetEstimateCommentsOrderedBy(orderBy));
            return View(estimateCommentViewModel);
        }

        // GET: EstimateComments/Details/5
        public async Task<IActionResult> Details(EstimateCommentViewModel estimateCommentViewModel)
        {
            estimateCommentViewModel ??= new EstimateCommentViewModel();

            var estimateComment = await _estimateCommentRepository.GetById(new GetEstimateCommentById(estimateCommentViewModel.Id));

            estimateCommentViewModel.Id = estimateComment.Id;
            estimateCommentViewModel.Contents = estimateComment.Contents;
            estimateCommentViewModel.DateCreated = estimateComment.DateCreated;
            estimateCommentViewModel.EstimateId = estimateComment.Estimate.Id;

            return estimateComment == new EstimateComment() ? NotFound() : View(estimateCommentViewModel);
        }

        // GET: EstimateComments/Create
        public IActionResult Create(EstimateCommentViewModel viewModel)
        {
            viewModel ??= new EstimateCommentViewModel();

            return View(viewModel);
        }

        // POST: EstimateComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed([Bind("EstimateId,Id,Contents,DateCreated")] EstimateCommentViewModel viewModel)
        {
            if (viewModel == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _estimateCommentRepository.Insert(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: EstimateComments/Edit/5
        public async Task<IActionResult> Edit(EstimateCommentViewModel viewModel)
        {
            EstimateComment? estimateComment = await _estimateCommentRepository.GetById(new GetEstimateCommentById(viewModel.Id));

            if (estimateComment == null)
            {
                return NotFound();
            }

            viewModel.EstimateComment = estimateComment;
            return View(viewModel);
        }

        // POST: EstimateComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstimateId,Id,Contents,DateCreated")] EstimateCommentViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _estimateCommentRepository.Update(new GetEstimateCommentById(id), viewModel);

                    return View(viewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await EstimateCommentExists(viewModel.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(viewModel);
        }

        // GET: EstimateComments/Delete/5
        public async Task<IActionResult> Delete(EstimateCommentViewModel viewModel)
        {
            viewModel.EstimateComment = await _estimateCommentRepository.GetById(new GetEstimateCommentById(viewModel.Id));
            return viewModel.EstimateComment == new EstimateComment() ? NotFound() : View(viewModel);
        }

        // POST: EstimateComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(EstimateCommentViewModel viewModel)
        {
            await _estimateCommentRepository.Delete(new GetEstimateCommentById(viewModel.Id));
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EstimateCommentExists(int id)
        {
            EstimateComment estimateComment = await _estimateCommentRepository.GetById(new GetEstimateCommentById((int)id));

            return estimateComment != null ? true : false;
        }
    }
}
