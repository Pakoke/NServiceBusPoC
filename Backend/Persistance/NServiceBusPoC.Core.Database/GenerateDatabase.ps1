Add-Type -Path '.\MySql.Data.dll'

$MySQLAdminUserName = 'NServiceBusPoCuser'
$MySQLAdminPassword = 'NServiceBusPoCpass'
$MySQLDatabase = 'NServiceBusPoCdb'
$MySQLHost = 'localhost'
$ConnectionString = "server=" + $MySQLHost + ";port=3306;uid=" + $MySQLAdminUserName + ";pwd=" + $MySQLAdminPassword + ";database="+$MySQLDatabase
Try {
	$files = Get-ChildItem  -Path . -Filter "*.sql"
	$Connection = New-Object MySql.Data.MySqlClient.MySqlConnection
	$Connection.ConnectionString = $ConnectionString
	$Connection.Open()

	write-host "Create the schema, if it doesn´t exist"
	$Command = New-Object MySql.Data.MySqlClient.MySqlCommand($Query, $Connection)
	$Command.CommandText = "CREATE DATABASE IF NOT EXISTS $MySQLDatabase;" #query to run.
	$iRowsAffected=$Command.ExecuteNonQuery()
	Write-Host "$iRowsAffected";

	#take every file and execute the query in every of them.
	foreach($file in $files)
	{
		write-host "$file loading"
		$Command = New-Object MySql.Data.MySqlClient.MySqlCommand($Query, $Connection)
		$Command.CommandText = Get-Content $file
		$iRowsAffected=$Command.ExecuteNonQuery()
		Write-Host "$iRowsAffected";
	}
pause 15
exit
  }

Catch {
  Write-Host "ERROR : Unable to run query : $query `n$Error[0]"
 }
Finally {
  $Connection.Close()
  }