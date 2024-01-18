CREATE OR REPLACE FUNCTION people_filter_paginate_fn(
	  PageNumber 			INTEGER
	, NumberOfItemsPerPage  INTEGER
	, OrderColumnIndex 	    INTEGER
	, Name 				    CHAR VARYING DEFAULT NULL
	, DateOfJoin 			DATE DEFAULT NULL
	, Type 					INTEGER DEFAULT NULL
	, Role 					INTEGER DEFAULT NULL
	, AdditionalRolesFlags 	BIGINT DEFAULT NULL
	, Address 				CHAR VARYING DEFAULT NULL
	, PhoneNumber 			CHAR VARYING DEFAULT NULL
	, Email 				CHAR VARYING DEFAULT NULL
	, Status 				INTEGER DEFAULT NULL
)
RETURNS SETOF people
LANGUAGE 'plpgsql'
AS $$
BEGIN
	RETURN QUERY (SELECT * FROM people);
END
$$