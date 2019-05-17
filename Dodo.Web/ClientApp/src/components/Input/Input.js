import React from 'react'
import { Input } from 'semantic-ui-react'

export default function TodoInput(props) {
  function onTodoInput(e) {
    if (e.keyCode === 13) {
      props.addTodoItem(e.target.value)
      e.target.value = ''
    }
  }

  return <Input fluid placeholder={props.placeholder} onKeyDown={onTodoInput} />
}
