import { useStateIfMounted } from "use-state-if-mounted"
import { useEffect } from "react"

/** хук для элементов на подобии выпадающих списков
 * Пример работы https://codesandbox.io/s/dropdown-menu-jzldk?file=/src/App.js:71-92
 */
export default function useDetectOutsideClick(
  el: React.RefObject<HTMLDivElement>,
  initialState?: boolean
): [boolean, (isActive: boolean) => any] {
  const [isActive, setIsActive] = useStateIfMounted(initialState || false)

  useEffect(() => {
    const listener = (e) => {
      // If the active element exists and is clicked outside of
      if (el.current !== null && !el.current.contains(e.target)) {
        setIsActive(!isActive)
      }
    }

    // If the item is active (ie open) then listen for clicks outside
    if (isActive) {
      window.addEventListener("click", listener)
    }

    return () => {
      window.removeEventListener("click", listener)
    }
  }, [isActive, el])

  return [isActive, setIsActive]
}
