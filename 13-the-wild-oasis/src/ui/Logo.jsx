import styled from 'styled-components';
import { useDarkMode } from '../context/DarkModeContext';

const StyledLogo = styled.div`
      text-align: center;
`;

const Img = styled.img`
      height: 9.6rem;
      width: auto;

      -webkit-user-drag: none;
      user-select: none;
      -moz-user-select: none;
      -webkit-user-select: none;
      -ms-user-select: none;
`;

function Logo() {
      const { isDarkMode } = useDarkMode();

      const src = isDarkMode ? '/logo-dark.png' : '/logo-light.png';

      return (
            <StyledLogo>
                  <Img src={src} alt="Logo" />
            </StyledLogo>
      );
}

export default Logo;
