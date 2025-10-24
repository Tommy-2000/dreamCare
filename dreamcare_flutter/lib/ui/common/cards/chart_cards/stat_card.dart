import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

import '../../../../logic/utils/constants.dart';
import '../../../../styles/colours.dart';

class StatCard extends StatefulWidget {
  final IconData? statIcon;
  final String? statTitle;
  final int? statNumber;

  const StatCard({super.key, required this.statIcon, required this.statTitle, required this.statNumber});

  @override
  State<StatCard> createState() => _StatCardState();
}

class _StatCardState extends State<StatCard> {
  @override
  Widget build(BuildContext context) {
    return Stack(children: [parentCard(context), childCard()]);
  }

  Widget parentCard(BuildContext context) {
    return Positioned.fill(child: Card(elevation: 3.0, color: cardColour));
  }

  Widget childCard() {
    return Padding(
      padding: const EdgeInsets.all(cardPadding),
      child: Center(
        child: Column(
          children: [
            Icon(
              widget.statIcon,
            ),
            Text(
              widget.statTitle!,
              style: GoogleFonts.montserrat(
                color: primaryTextColour,
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
            Text(widget.statNumber.toString(), style: GoogleFonts.montserrat(
              color: primaryTextColour,
              fontSize: 40,
              fontWeight: FontWeight.bold,
            ),),
          ],
        ),
      ),
    );
  }

  GlobalKey _getGlobalKey() {
    return GlobalKey();
  }
}
