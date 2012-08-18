{print} = require 'util'
{spawn} = require 'child_process'

task 'build', 'Build CoffeeScript source files', ->
  coffee = spawn 'coffee', ['-cw', 'livereload.coffee']
  coffee.stdout.on 'data', (data) -> print data.toString()
