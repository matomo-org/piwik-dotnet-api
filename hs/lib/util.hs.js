// https://github.com/julienmoumne/hotshell-util

exports.prompt = function (config) {
    var cmd = ''
    _(config.vars).each(function (el) {
        cmd += 'echo -n "' + el.prompt + ': "; read ' + el.name + '; '
    })
    config.cmd = cmd + config.cmd;

    return addItem(config, arguments)
}

exports.confirm = function (config) {
    config.cmd =
        'read -r -p "Are you sure? [y/n] " resp; ' +
        'if [[ $resp = y ]]; ' +
        'then ' + config.cmd + '; ' +
        'fi';

    return addItem(config, arguments)
}

function addItem(config, args) {
    var addItem = (args[1] !== void 0 ? args[1] : true);
    if(addItem)
        item(config)
    return config
}
