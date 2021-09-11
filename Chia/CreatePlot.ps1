new-alias chia $ENV:LOCALAPPDATA\chia-blockchain\app-*\resources\app.asar.unpacked\daemon\chia.exe
if ($args[1] like "create")
{
	chia $args[0] $args[1] -k 32 -b 4000 -c xch1qvwe2chw7psealmumd845rdf2qc8tduv4ent7facjsnadxng02hsjpj9e7
}
chia $args[0] $args[1]
# write-host $args[0]