import 'package:flutter/material.dart';

import '../../../styles/colours.dart';

class SecondaryButton extends StatefulWidget {
  const SecondaryButton({super.key, required this.buttonText});

  final String buttonText;

  @override
  State<SecondaryButton> createState() => _SecondaryButtonState();
}

class _SecondaryButtonState extends State<SecondaryButton> {
  @override
  Widget build(BuildContext context) {
    return MaterialButton(
      color: secondaryThemeColour,
      textColor: whiteTextColour,
      shape: StadiumBorder(),
      mouseCursor: SystemMouseCursors.click,
      onPressed: () {},
      child: Text(widget.buttonText),
    );
  }
}
