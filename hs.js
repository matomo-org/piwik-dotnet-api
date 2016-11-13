var prompt = require('./hs/lib/util.hs.js').prompt

item({desc: 'piwik-dotnet-api'}, function() {
  prompt({
    key: 'p',
    desc: 'publish new version',
    cmd: './publish.sh $version',
    vars: [{name: 'version', prompt: 'new version'}]
  })
})
