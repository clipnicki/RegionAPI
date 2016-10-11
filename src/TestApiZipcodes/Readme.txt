

Testing Region API
------------------

Assumes Debug settings:
	Profile and Launch -> IIS Express
	Enable Anonymous authentication checked

Get (all Regions)
-----------------
Lauch application (Crtl F5)
Browser should navigate to http://localhost:65109/api/region (port is set locally in project settings - App URL)
Expected result: "in memory" sample Region object should be return in JSON format
If target browser is IE you may get a download (JSON results returned web page in Firefox & Chrome)

Create
------
Lauch Chrome Postman app
HTTP method: POST
Click Body radio button
Click raw radio button
Set Type to JSON
Enter a Region item like below into the key value editor section
[{"key":"","name":"Region2","regionGroups":[{"startZip":"06005","endZip":"06008"},{"startZip":"06110","endZip":"06010"}]}]
Click Send button
Expected result: should get a 201 response and listing of just added Region object in lower response panel
Test newly added Region object: refresh browser pointing to http://localhost:65109/api/region in GET test above


Modify (Put)
------------
Similar to create - Postman App
Refresh GET to verify existing Region item key
HTTP method: PUT
Enter URL from above GET: e.g. http://localhost:65109/api/region/60d32962-206b-402d-85cb-05e09bc477b8
Enter a modified Region item like below (with above key) into the key value editor section
{"key":"60d32962-206b-402d-85cb-05e09bc477b8","name":"Region1","regionGroups":[{"startZip":"06108","endZip":"06110"},{"startZip":"06115","endZip":"06115"}]}
Expected result: should get a 204 NoContent response (check headers section in Postman)
After refreshing Chrome browser page should see modified Region JSON returned

Delete
------
Lauch application (to refresh Region content to default single Region)
Note returned key of item e.g. c2f1b71e-caee-45d6-855a-76791b037396
Launch Postman
HTTP method: DELETE
Modify URL like -> http://localhost:65109/api/region/c2f1b71e-caee-45d6-855a-76791b037396
CLick Send button
Expected result: should get a 204 NoContent response
After refreshing Chrome broweser should see an empty result '[]' becuase the single default Region was deleted


Business Rules TODOs:
Regions should be validated to contain contiguous RegionGroups -> ConvertToInt(StripLeadingZero(endZip)) > ConvertToInt(StripLeadingZero(endZip))
Add helper method(s) e.g. Get List<string> of zipcodes within a RegionGroup
...
