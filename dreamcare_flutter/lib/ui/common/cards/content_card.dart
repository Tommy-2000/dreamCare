import '../../../logic/utils/constants.dart';
import 'package:flutter/material.dart';

import '../../../styles/colours.dart';

class ContentCard extends StatefulWidget {
  final Widget child;

  const ContentCard({super.key, required this.child});

  @override
  State<ContentCard> createState() => _ContentCardState();
}

class _ContentCardState extends State<ContentCard> {
  @override
  Widget build(BuildContext context) {
    return Card(
      color: cardColour,
      elevation: 3.0,
      child: Padding(
        padding: EdgeInsets.all(cardPadding),
        child: widget.child,
      ),
    );
  }
}
