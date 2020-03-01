using ForTest.Core.Data.Enums;
using ForTest.Core.Models;
using ForTest.Core.Service.Track;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ForTest.Core.Service
{
    public class CustomerService : IDisposable, ICustomerService
    {
        private forTestEntities db = new forTestEntities();
        private readonly ITrackService _trackService;

        public CustomerService(ITrackService trackService)
        {
            _trackService = trackService;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IPagedList<Customer> GetForView(CustomerFiltering customerFiltering, int page, int itemsPerPage)
        {
            var customers = db.Customer.AsNoTracking().AsQueryable();

            #region filter

            List<string> trackEvent = new List<string>();

            if (customerFiltering.CustomerId > 0)
            {
                trackEvent.Add(ETrackEvent.Filter_CustomerId.ToString());
                customers = customers.Where(x => x.Id == customerFiltering.CustomerId);
            }

            if (!string.IsNullOrEmpty(customerFiltering.Name))
            {
                trackEvent.Add(ETrackEvent.Filter_Name.ToString());
                customers = customers.Where(x => x.Name.Contains(customerFiltering.Name));
            }

            if (customerFiltering.BirthDayFrom.HasValue && customerFiltering.BirthDayTo.HasValue)
            {
                trackEvent.Add(ETrackEvent.Filter_BirthDay.ToString());
                customers = customers.Where(x => x.BirthDay >= customerFiltering.BirthDayFrom.Value && x.BirthDay <= customerFiltering.BirthDayTo);
            }

            if (customerFiltering.Gender.HasValue)
            {
                trackEvent.Add(ETrackEvent.Filter_Gender.ToString());
                customers = customers.Where(x => x.Gender == customerFiltering.Gender);
            }

            if (customerFiltering.QuantityRequest > 0)
            {
                trackEvent.Add(ETrackEvent.Filter_QuantityRequest.ToString());
                customers = customers.Where(x => x.QuantityRequest > customerFiltering.QuantityRequest);
            }

            #endregion

            #region sort order

            switch (customerFiltering.Sorting)
            {
                case ESortOrder.AscByCustomerId:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Asc_CustomerId.ToString());
                        customers = customers.OrderBy(x => x.Id);
                        break;
                    }
                case ESortOrder.DescByCustomerId:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Desc_CustomerId.ToString());
                        customers = customers.OrderByDescending(x => x.Id);
                        break;
                    }
                case ESortOrder.AscByName:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Asc_Name.ToString());
                        customers = customers.OrderBy(x => x.Name);
                        break;
                    }
                case ESortOrder.DescByName:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Desc_Name.ToString());
                        customers = customers.OrderByDescending(x => x.Name);
                        break;
                    }
                case ESortOrder.AscByBirthDay:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Asc_BirthDay.ToString());
                        customers = customers.OrderBy(x => x.BirthDay);
                        break;
                    }
                case ESortOrder.DescByBirthDay:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Desc_BirthDay.ToString());
                        customers = customers.OrderByDescending(x => x.BirthDay);
                        break;
                    }
                case ESortOrder.AscByGender:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Asc_Gender.ToString());
                        customers = customers.OrderBy(x => x.Gender);
                        break;
                    }
                case ESortOrder.DescByGender:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Desc_Gender.ToString());
                        customers = customers.OrderByDescending(x => x.Gender);
                        break;
                    }
                case ESortOrder.AscByQuantityRequest:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Asc_QuantityRequest.ToString());
                        customers = customers.OrderBy(x => x.QuantityRequest);
                        break;
                    }
                case ESortOrder.DescByQuantityRequest:
                    {
                        trackEvent.Add(ETrackEvent.Sort_Desc_QuantityRequest.ToString());
                        customers = customers.OrderByDescending(x => x.QuantityRequest);
                        break;
                    }
                default:
                    customers = customers.OrderBy(x => x.Id);
                    break;
            }

            #endregion

            if (trackEvent.Any())
                _trackService.TrackEvents(trackEvent);

            return customers.ToPagedList(page, itemsPerPage);
        }
    }
}
