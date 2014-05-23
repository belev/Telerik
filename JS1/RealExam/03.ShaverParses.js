function Solve(args) {
    var n = parseInt(args[0]);

    var allModels = [];

    for (var i = 0; i < n; i++) {
        var nameAndValue = args[i + 1].split(':');

        if (nameAndValue[1].indexOf(',') !== -1) {
            allModels[nameAndValue[0].trim()] = parseParameteres(nameAndValue[1].trim());
        } else {
            allModels[nameAndValue[0].trim()] = nameAndValue[1].trim();
        }
    }

    var m = parseInt(args[n + 1]);
    var lines = [];
    for (var j = n + 2; j < args.length; j++) {
        lines[j - n - 2] = args[j];
    }

    var res = '';
    var commandCode = [];


    for (var i = 0; i < lines.length; i++) {
        var curLine = lines[i];

        for (var j = 0; j < curLine.length; j++) {
            var curChar = curLine[j];

            if (curChar == '@') {
                if (j + 1 < curLine.length && curLine[j + 1] !== '@') {
                    if (curLine.indexOf('{') !== -1) {
                        while (curLine.indexOf('}') === -1) {
                            commandCode.push(curLine);

                            i++;
                            curLine = lines[i];
                        }

                        // return some result
                        processCommandCode(commandCode, allModels);
                        commandCode = [];
                    } else {
                        if (curLine.indexOf('renderSection') !== -1) {
                            commandCode.push(curLine);

                            // return some result
                            res += '\n';
                            res += processCommandCode(commandCode, allModels);
                            commandCode = [];
                            break;
                        }
                    }
                    continue;
                } else if (j + 1 < curLine.length && curLine[j + 1] == '@') {
                    if (curChar == '') {
                        res += '\n';
                    } else {
                        j++;
                        curChar = curLine[j];
                        res += curChar;
                    }

                    continue;
                }
            }

            if (curChar == '') {
                res += '\n';
            } else {
                res += curChar;

                if (j == curLine.length - 1 && curChar !== '') {
                    res += '\n';
                }
            }
        }
    }

    return res;

    function parseParameteres(parameters) {
        parameters = parameters.split(',');

        var result = [];

        for (var i = 0; i < parameters.length; i++) {
            result[i] = parameters[i].trim();
        }

        return result;
    }

    function processCommandCode(code) {
        var firstLine = code[0];

        if (firstLine.indexOf('if') !== -1) {
            //process if command
        }
        else if (firstLine.indexOf('renderSection') !== -1) {
            return renderSection(firstLine, allModels);
        }
        else if (firstLine.indexOf('foreach') !== -1) {
            //process foreach command
        }
        else if (firstLine.indexOf('section') !== -1) {
            defineSection(code, allModels);
        }

        for (var i = 1; i < code.length; i++) {
            var line = code[i];
        }
    }

    function renderSection(code) {
        code = new String(code);

        var modelName = code.substring(code.indexOf('"') + 1, code.lastIndexOf('"'));
        return allModels[modelName];
    }

    function defineSection(code) {
        var firstWhitespaceIndex = code[0].indexOf(' ');
        var index = code[0].indexOf(' ', firstWhitespaceIndex + 1);

        var name = code[0].substring(firstWhitespaceIndex + 1, index);
        var value = '';

        for (var i = 1; i < code.length; i++) {
            value += code[i];

            if (i !== code.length - 1) {
                value += '\n';
            }
        }

        allModels[name] = value;
    }
}

(function () {
    var test = [
        [
            '0',
            '3',
            '<div>',
            '    <h1>@@Telerik Academy</h1>',
            '<div>'
    ]
    ,
    [
        '0',
        '12',
'@section menu {',
'<ul>',
'    <li>Home</li>',
'    <li>About us</li>',
'</ul>',
'}',
'<div>',
'    <h1>Telerik Academy</h1>',
'    <div>',
'        @renderSection("menu")',
'    </div>',
'</div>',
    ]
    ];

    console.log(Solve(test[1]));
}());