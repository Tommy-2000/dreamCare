import 'package:flutter/material.dart';
import 'package:gap/gap.dart';

import '../../../styles/colours.dart';

class SecondaryButton extends StatefulWidget {
  const SecondaryButton({super.key, required this.buttonText, this.buttonIcon, this.buttonOnPressed});

  final String buttonText;
  final Icon? buttonIcon;
  final Function? buttonOnPressed;

  @override
  State<SecondaryButton> createState() => _SecondaryButtonState();
}

class _SecondaryButtonState extends State<SecondaryButton> {
  @override
  Widget build(BuildContext context) {
    return MaterialButton(
      color: secondaryThemeColour,
      textColor: secondaryTextColour,
      shape: StadiumBorder(),
      mouseCursor: SystemMouseCursors.click,
      onPressed: () {
        widget.buttonOnPressed;
      },
      child: Row(
        children: [
          Text(widget.buttonText),
          Gap(5),
          ?widget.buttonIcon
        ],
      ),
    );
  }
}
