import 'package:flutter/material.dart';
import 'package:gap/gap.dart';

import '../../../styles/colours.dart';

class PrimaryButton extends StatefulWidget {
  const PrimaryButton({super.key, required this.buttonText, this.buttonIcon, this.buttonOnPressed});

  final String buttonText;
  final Icon? buttonIcon;
  final Function? buttonOnPressed;

  @override
  State<PrimaryButton> createState() => _PrimaryButtonState();
}

class _PrimaryButtonState extends State<PrimaryButton> {
  @override
  Widget build(BuildContext context) {
    return MaterialButton(
      color: primaryThemeColour,
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
