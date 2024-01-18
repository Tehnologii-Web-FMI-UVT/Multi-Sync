using AspNetCore.Identity.Dapper;

using Dapper;

using DataLayer.Models;

namespace DataLayer.Repositiory
{
    public interface IPeopleRepository
    {
        public Task<People> GetPeopleEntry(ulong id);

        public Task<IEnumerable<People>> FilterPeople(PeopleFilterParams peopleFilterParams);

        public Task<bool> Create(People people);

        public Task<bool> Update(People people);
    }

    public class PeopleRepository : IPeopleRepository
    {
        private readonly IDbConnectionFactory mDbConnectionFactory;

        public PeopleRepository(IDbConnectionFactory dbConnectionFactory)
        {
            mDbConnectionFactory = dbConnectionFactory;
        }

        public async Task<People> GetPeopleEntry(ulong id)
        {
            using (var DBConnection = mDbConnectionFactory.Create())
            {
                return await DBConnection.QuerySingleAsync<People>(@"SELECT * FROM people WHERE id=@Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<People>> FilterPeople(PeopleFilterParams peopleFilterParams)
        {
            using (var DBConnection = mDbConnectionFactory.Create())
            {
                return await DBConnection
                    .QueryAsync<People>(@"SELECT * FROM public.people_filter_paginate_fn(@PageNumber 			
                                                                         , @NumberOfItemsPerPage::integer 
                                                                         , @OrderColumnIndex::integer 	 
                                                                         , @OrderAscOrDesc::bit
                                                                         , @Name::character varying 				    
                                                                         , @Gender::integer 				
                                                                         , @DateOfJoin::DATE		
                                                                         , @DOB::DATE	 					
                                                                         , @DateOfBaptize::DATE	 		
                                                                         , @DateOfDecease::DATE	 		
                                                                         , @MaritalStatus::integer  		
                                                                         , @SocialStatus::integer  			
                                                                         , @Type::integer  					
                                                                         , @Role::integer  					
                                                                         , @AdditionalRolesFlags::integer 	
                                                                         , @JoinProcessType::integer  		
                                                                         , @Address::character varying 	 				
                                                                         , @PhoneNumber::character varying 	 			
                                                                         , @Email::character varying 	 				
                                                                         , @HolySpiritBaptized::bit 	
                                                                         , @Status::integer)"
                                    , new
                                    {
                                        PageNumber = peopleFilterParams.PageNumber,
                                        NumberOfItemsPerPage = peopleFilterParams.NumberOfItemsPerPage,
                                        OrderColumnIndex = peopleFilterParams.OrderColumnIndex,
                                        OrderAscOrDesc = peopleFilterParams.OrderAscOrDesc ? 1 : 0,
                                        Name = peopleFilterParams.Name,
                                        Gender = peopleFilterParams.Gender,
                                        DateOfJoin = peopleFilterParams.DateOfJoin,
                                        DOB = peopleFilterParams.DOB,
                                        DateOfBaptize = peopleFilterParams.DateOfBaptize,
                                        DateOfDecease = peopleFilterParams.DateOfDecease,
                                        MaritalStatus = peopleFilterParams.MaritalStatus,
                                        SocialStatus = peopleFilterParams.SocialStatus,
                                        Type = peopleFilterParams.Type,
                                        Role = peopleFilterParams.Role,
                                        AdditionalRolesFlags = peopleFilterParams.AdditionalRolesFlags,
                                        JoinProcessType = peopleFilterParams.JoinProcessType,
                                        Address = peopleFilterParams.Address,
                                        PhoneNumber = peopleFilterParams.PhoneNumber,
                                        Email = peopleFilterParams.Email,
                                        HolySpiritBaptized = (peopleFilterParams.HolySpiritBaptized.HasValue ? peopleFilterParams.HolySpiritBaptized.Value ? 1 : 0 : (int?)null),
                                        Status = peopleFilterParams.Status
                                    });
            }
        }

        public async Task<bool> Create(People people)
        {
            using (var DBConnection = mDbConnectionFactory.Create())
            {
                return 0 < (await DBConnection.ExecuteScalarAsync<int>(@"INSERT INTO 
                        people(
                              FirstName
                            , LastName
                            , LastName
                            , Gender
                            , DateOfJoin
                            , DOB
                            , DateOfBaptize
                            , DateOfDecease
                            , MaritalStatus
                            , SocialStatus
                            , Type
                            , Role
                            , AdditionalRolesFlags
                            , JoinProcessType
                            , Address
                            , PhoneNumber
                            , Email
                            , HolySpiritBaptized
                            , Status
                        ) 
                        VALUES(
                              @FirstName
                            , @LastName
                            , @Gender
                            , @DateOfJoin
                            , @DOB
                            , @DateOfBaptize
                            , @DateOfDecease
                            , @MaritalStatus
                            , @SocialStatus
                            , @Type
                            , @Role
                            , @AdditionalRolesFlags
                            , @JoinProcessType
                            , @Address
                            , @PhoneNumber
                            , @Email
                            , @HolySpiritBaptized
                            , @Status)"
                        , new
                        {
                            FirstName = people.FirstName,
                            LastName = people.LastName,
                            Gender = people.Gender,
                            DateOfJoin = people.DateOfJoin,
                            DOB = people.DOB,
                            DateOfBaptize = people.DateOfBaptize,
                            DateOfDecease = people.DateOfDecease,
                            MaritalStatus = people.MaritalStatus,
                            SocialStatus = people.SocialStatus,
                            Type = people.Type,
                            Role = people.Role,
                            AdditionalRolesFlags = people.AdditionalRolesFlags,
                            JoinProcessType = people.JoinProcessType,
                            Address = people.Address,
                            PhoneNumber = people.PhoneNumber,
                            Email = people.Email,
                            HolySpiritBaptized = people.HolySpiritBaptized,
                            Status = people.Status
                        }));
            }
        }

        public async Task<bool> Update(People people)
        {
            using (var DBConnection = mDbConnectionFactory.Create())
            {
                return 0 < (await DBConnection.ExecuteScalarAsync<int>(@"UPDATE people SET
                              FirstName            = @FirstName
                            , LastName             = @LastName
                            , Gender               = @Gender
                            , DateOfJoin           = @DateOfJoin
                            , DOB                  = @DOB
                            , DateOfBaptize        = @DateOfBaptize
                            , DateOfDecease        = @DateOfDecease
                            , MaritalStatus        = @MaritalStatus
                            , SocialStatus         = @SocialStatus
                            , Type                 = @Type
                            , Role                 = @Role
                            , AdditionalRolesFlags = @AdditionalRolesFlags
                            , JoinProcessType      = @JoinProcessType
                            , Address              = @Address
                            , PhoneNumber          = @PhoneNumber
                            , Email                = @Email
                            , HolySpiritBaptized   = @HolySpiritBaptized
                            , Status               = @Status
                            WHERE Id = @Id"
                        , new
                        {
                            Id = people.Id,
                            FirstName = people.FirstName,
                            LastName = people.LastName,
                            Gender = people.Gender,
                            DateOfJoin = people.DateOfJoin,
                            DOB = people.DOB,
                            DateOfBaptize = people.DateOfBaptize,
                            DateOfDecease = people.DateOfDecease,
                            MaritalStatus = people.MaritalStatus,
                            SocialStatus = people.SocialStatus,
                            Type = people.Type,
                            Role = people.Role,
                            AdditionalRolesFlags = people.AdditionalRolesFlags,
                            JoinProcessType = people.JoinProcessType,
                            Address = people.Address,
                            PhoneNumber = people.PhoneNumber,
                            Email = people.Email,
                            HolySpiritBaptized = people.HolySpiritBaptized,
                            Status = people.Status
                        }));
            }
        }
    }
}
